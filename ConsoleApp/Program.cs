using BusUserServices;
using DB_TestServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProviderServices;
using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using UtilitiesServices;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Regis service to application
            var _services = Startup.ConfigureServices();
            var _builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
            var _IConfiguration = (IConfiguration)_builder.Build();

            _services.AddSingleton<IConfiguration>(_IConfiguration);
            UtilitiesServicesBuilder.AddServices(_services, _IConfiguration);
            DB_TestServicesServicesBuilder.AddServices(_services, _IConfiguration);
            BusAServicesBuilder.AddServices(_services, _IConfiguration);
            ProviderServicesBuilder.AddServices(_services, _IConfiguration);
            var _IServiceCollection = _services.BuildServiceProvider();


            //Get service
            var _IBusAUserServices = _IServiceCollection.GetService<IBusAUserServices>();
            var _list_user = new string[] { "user_a", "user_b" };

            foreach (var _user in _list_user)
            {
                Console.WriteLine(_user);
                Console.WriteLine(_IBusAUserServices.GenerateTokenAsync(_user).Result);
                Console.WriteLine("");
            }
        }


        public static class Startup
        {
            public static IServiceCollection ConfigureServices()
            {
                var serviceCollection = new ServiceCollection();

                // We'll come back here later to set up an entry point and
                // our services

                return serviceCollection;
            }
        }

    }
}
