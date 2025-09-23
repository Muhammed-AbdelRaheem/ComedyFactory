using Domain.Models;
using Hangfire;
using Imageflow.Fluent;
using Imageflow.Server;
using IoC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Net.Http.Headers;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Web;
namespace ComedyFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            var mvcBuilder = builder.Services.AddControllersWithViews(options =>
            {
                options.EnableEndpointRouting = false;
            })
              .AddSessionStateTempDataProvider()
              .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                  options.JsonSerializerOptions.PropertyNamingPolicy = null;
              })
              .AddCookieTempDataProvider()
              .AddXmlSerializerFormatters()
              .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opts =>
              {
                  opts.ResourcesPath = "Resources";
              })
              .AddDataAnnotationsLocalization(options =>
              {
                  options.DataAnnotationLocalizerProvider = (type, factory) =>
                  {
                      var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                      return factory.Create("SharedResource", assemblyName.Name);
                  };
              });


            //// Add services to the container.
            //builder.Services.AddControllersWithViews();

            IOH.DependencyContainer.RegisterServices(builder.Services, builder.Configuration);



            builder.Services.ConfigureApplicationCookie(options =>
            {

                options.Cookie.HttpOnly = false;
                options.ExpireTimeSpan = TimeSpan.FromDays(3);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/Login";
                options.SlidingExpiration = true;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = async (ctx) =>
                    {
                        ctx.Response.Redirect("/account/login?ReturnUrl=" + HttpUtility.UrlEncode(ctx.Request.Path.ToString()));
                    },
                    OnRedirectToAccessDenied = async (ctx) =>
                    {
                        ctx.Response.Redirect("/account/login?ReturnUrl=" + HttpUtility.UrlEncode(ctx.Request.Path.ToString()));
                    }
                };

            });

            builder.Services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("language", typeof(LanguageRouteConstraint));
            });



            var app = builder.Build();



            app.UseImageflow(new ImageflowMiddlewareOptions()
                .SetMapWebRoot(true)
                .SetAllowDiskCaching(true)
                .SetAllowCaching(true)
                .SetDefaultCacheControlString("public, max-age=2592000")
                .AddCommandDefault("down.filter", "mitchell")
                .AddCommandDefault("f.sharpen", "15")
                .AddCommandDefault("webp.quality", "100")
                .AddCommandDefault("jpg.quality", "100")
                .AddCommandDefault("jpeg.quality", "100")
                .AddCommandDefault("png.quality", "100")
                .AddCommandDefault("ignore_icc_errors", "true")
                .SetUsePresetsExclusively(false)
                .AddPreset(new PresetOptions("large", PresetPriority.DefaultValues)
                    .SetCommand("width", "1024")
                    .SetCommand("height", "1024")
                    .SetCommand("mode", "max"))
                .SetJobSecurityOptions(new SecurityOptions()
                    .SetMaxDecodeSize(new FrameSizeLimit(100000, 100000, 1000))
                    .SetMaxFrameSize(new FrameSizeLimit(100000, 100000, 1000))
                    .SetMaxEncodeSize(new FrameSizeLimit(100000, 100000, 1000)))
            );


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24 * 7;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            //use hangfire
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
              name: "Default",
              pattern: "{language}/{controller=Home}/{action=Index}/{id?}",
              constraints: new
              {
                  language = new RegexRouteConstraint("^[a-z]{2}(?:-[A-Z]{2})?$")
              }
            );

            app.MapControllerRoute(
                name: "HomePage",
                pattern: "{*url}",
                defaults: new { controller = "Home", action = "Redirect" }
            );

            app.MapControllerRoute(
                name: "Redirect",
                pattern: "",
                defaults: new { controller = "Home", action = "Redirect" }
            );

            app.Run();
        }
    }
}
