using DB_TestServices.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Infrastructure;
using UserService.Infrastructure.SpecificRepository;

namespace DB_TestServices
{
 
    public static class DB_TestServicesServicesBuilder
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DB_TestContext>(options => options.UseSqlServer(configuration["APP_CONFIG:ConnectionString"]));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAuthorizeRepository, UserAuthorizeRepository>();

            return services;
        }

    }
}
