using BusUserServices;
using DB_TestServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProviderServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilitiesServices;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _IConfiguration = configuration;
        }

        public IConfiguration _IConfiguration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            //Regis service to application
            UtilitiesServicesBuilder.AddServices(services, _IConfiguration);
            DB_TestServicesServicesBuilder.AddServices(services, _IConfiguration);
            BusAServicesBuilder.AddServices(services, _IConfiguration);
            ProviderServicesBuilder.AddServices(services, _IConfiguration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var pathBase = _IConfiguration.GetValue<string>("APP_CONFIG:Base_Path");
            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
