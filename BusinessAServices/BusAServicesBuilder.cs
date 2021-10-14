using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusUserServices
{
  
    public static class BusAServicesBuilder
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBusAUserServices, BusAUserServices>();
            return services;
        }

    }


}
