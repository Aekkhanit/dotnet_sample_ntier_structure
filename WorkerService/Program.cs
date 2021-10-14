using BusUserServices;
using DB_TestServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProviderServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UtilitiesServices;

namespace WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //Regis service to application

                    var _builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
                    var _IConfiguration = (IConfiguration)_builder.Build();


                    services.AddSingleton<IConfiguration>(_IConfiguration);
                    UtilitiesServicesBuilder.AddServices(services, _IConfiguration);
                    DB_TestServicesServicesBuilder.AddServices(services, _IConfiguration);
                    BusAServicesBuilder.AddServices(services, _IConfiguration);
                    ProviderServicesBuilder.AddServices(services, _IConfiguration);


                    services.AddHostedService<Worker>();
                });
    }
}
