

using Data.Application.AutoMapper;
using Data.Context;
using Data.Service;
using Domain.Models;
using Hangfire;
using IoC;
using IOH.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using reCAPTCHA.AspNetCore;
using System.Globalization;
namespace IOH
{
    public class DependencyContainer
    {
        public IConfiguration Configuration { get; }
        public DependencyContainer(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<DependencyContainer>();
            });

            //  services.AddDbContext<WriteDbContext>(options => options.UseNpgsql(Config.Write_DefaultConnection,
            //npgsqlOptionsAction: sqlOptions => { sqlOptions.EnableRetryOnFailure(); }));

            //  services.AddDbContext<ReadDBContext>(options => options.UseNpgsql(Config.Read_DefaultConnection,
            //  npgsqlOptionsAction: sqlOptions => { sqlOptions.EnableRetryOnFailure(); }));
            services.AddDbContext<WriteDbContext>(options =>
      options.UseSqlServer(Config.Write_DefaultConnection));

            services.AddDbContext<ReadDBContext>(options =>
                options.UseSqlServer(Config.Read_DefaultConnection));

            //hangfire setting
            services.AddHangfire(config =>
            
                    //config.UsePostgreSqlStorage(options =>
                    //{
                    //    options.UseNpgsqlConnection(Config.Write_DefaultConnection);
                    //})
                    config.UseSqlServerStorage(Config.Write_DefaultConnection));

            


            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<WriteDbContext>()
            .AddDefaultTokenProviders();


            services.Configure<RecaptchaSettings>(configuration.GetSection("RecaptchaSettings"));

            services.AddTransient<IRecaptchaService, RecaptchaService>();



            RegisterModelsServices.RegisterModelServices(services);



            services.AddHttpContextAccessor();
            // Configure supported cultures and localization options
            services.Configure<RequestLocalizationOptions>(options => {
                var supportedCultures = new[]
                {
                    new CultureInfo("ar-EG"),
                    new CultureInfo("ar"),
                    new CultureInfo("en-GB"),
                };
                var cultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider()
                };
                options.DefaultRequestCulture = new RequestCulture("en-GB", "en-GB");

                options.SupportedCultures = supportedCultures;

                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders = cultureProviders;

                options.RequestCultureProviders.Insert(0, new RouteCultureProvider(options.DefaultRequestCulture));
            });

            services.AddDistributedMemoryCache();

      

     
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddHttpContextAccessor();



        }

        public static void RegisterConfigure(IApplicationBuilder app, IWebHostEnvironment env, IServiceCollection services)
        {

            //if (env.IsDevelopment())
            //{
            //    services.AddDatabaseDeveloperPageExceptionFilter();
            //}
            app.UseResponseCompression();
            //  app.UseHttpsRedirection();

            app.UseSession();

           

            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOptions.Value);

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseCookiePolicy();

        }


    }
}