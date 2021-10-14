using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UtilitiesServices.JWT;
using UtilitiesServices.Logger;

namespace UtilitiesServices
{
    public static class UtilitiesServicesBuilder
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFTPAdapterServices, FTPAdapterServices>();
            services.AddTransient<IDBAdapterServices, DBAdapterServices>();
            services.AddTransient<ICustomLoggerServices, CustomLoggerServices>();


            services.AddScoped<IJwtServices, JwtServices>();             

            return services;
        }

    }
}
