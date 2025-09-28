using Hangfire;
using IoC.Resources;
using IOH;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.AddSession(options =>
            {

                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

            });

            // Add services to the container.
            builder.Services.AddControllersWithViews(option => option.EnableEndpointRouting = false)
    .AddSessionStateTempDataProvider()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    })
    .AddCookieTempDataProvider()
    .AddXmlSerializerFormatters()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
    opts => { opts.ResourcesPath = "Resources"; })
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
            return factory.Create("SharedResource", assemblyName.Name);
        };

    });
            DependencyContainer.RegisterServices(builder.Services,builder.Configuration);



            var app = builder.Build();

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
                OnPrepareResponse = ctx => {
                    const int durationInSeconds = 60 * 60 * 24 * 7;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });

            //if (!builder.Environment.IsDevelopment())
            //{
            //    app.UseStaticFiles(new StaticFileOptions
            //    {
            //        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @".well-known")),
            //        RequestPath = new PathString("/.well-known"),
            //        ServeUnknownFileTypes = true// serve extensionless file
            //    });
            //}
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            //use hangfire
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
   name: "Shifts",
   pattern: "Shifts/{action}/{tournamentId}/{calendarId}/{scheduleId}/{id?}",
   defaults: new { controller = "Shifts", action = "Index" });

            app.MapControllerRoute(
                name: "WeightRangeWithDays",
                pattern: "WeightRangeWithDays/{action}/{tournamentId}/{id?}",
                defaults: new { controller = "WeightRangeWithDays", action = "Index" });

            app.MapControllerRoute(
                name: "CalendarSettings",
                pattern: "CalendarSettings/{action}/{tournamentId}/{id?}",
                defaults: new { controller = "CalendarSettings", action = "Index" });

            app.MapControllerRoute(
                name: "Blocks",
                pattern: "Blocks/{action}/{blockType}/{id?}",
                defaults: new { controller = "Blocks", action = "Index" });


            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
            name: "dashboard",
            pattern: "{*url}",
            defaults: new { controller = "Home", action = "Index" });
            app.Run();
        }
    }
}
