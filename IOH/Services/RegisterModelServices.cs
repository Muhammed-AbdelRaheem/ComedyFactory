using Data.IRepository;
using Data.NotificationHandler;
using Data.Repository;
using Data.Service;
using Domain.Models.NotificationHandlerVM;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOH.Service
{
    public class RegisterModelsServices
    {
        public static void RegisterModelServices(IServiceCollection services)
        {
            services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();
            services.AddScoped<IBlockRepository, BlockRepository>();
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IApiClientRepository, ApiClientRepository>();
            services.AddScoped<IErrorMessageRepository, ErrorMessageRepository>();
  
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<IBlockRepository, BlockRepository>();
  
            services.AddScoped<GetHeaders>();

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();


            services.AddScoped<ILogRepository, LogRepository>();

            services.AddScoped<IDesireRepository, DesireRepository>();

            services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();
            services.AddScoped<IMasterCategoryRepository, MasterCategoryRepository>();
            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();



            #region NotificationHandler
            services.AddScoped<INotificationHandler<LogAddViewModel>, Log_N>();



            //services.AddScoped<INotificationHandler<DeleteUserByProviderVM>, DeleteUserByProvider_N>();
            //services.AddScoped<INotificationHandler<UpdateUserHandlerVM>, Update_User_N>();
            //services.AddScoped<INotificationHandler<AddUserRoleHandlerVM>, AddUserRole_N>();
            #endregion

        }
    }
}
