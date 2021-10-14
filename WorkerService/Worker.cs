using BusUserServices;
using DB_TestServices.GenericRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProviderServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UserService.Infrastructure;
using UserService.Infrastructure.SpecificRepository;

namespace WorkerService
{


    public class Worker : BackgroundService
    {
        private bool _InProcess;
        private readonly IServiceProvider _IServiceProvider;
        private readonly IConfiguration _IConfiguration;
        public Worker(IServiceProvider IServiceProvider, IConfiguration IConfiguration)
        {

            var _builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

            _IConfiguration = (IConfiguration)_builder.Build();
            _IServiceProvider = IServiceProvider;

            _InProcess = false;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    if (now.Minute % 2 == 0)
                    {

                        if (!_InProcess)
                        {
                            var _list = new string[] { "user_a", "user_b" };
                            using (var scope = _IServiceProvider.CreateScope())
                            {

                                var _IBusAUserServices = scope.ServiceProvider.GetRequiredService<IBusAUserServices>();
                                foreach (var _user in _list)
                                {
                                    Console.WriteLine(_user);
                                    Console.WriteLine(await _IBusAUserServices.GenerateTokenAsync(_user));
                                    Console.WriteLine("");
                                }
                            }

                        }
                    }
                    else
                    {
                        _InProcess = false;
                    }

                }
                catch (Exception ex)
                {

                }

                await Task.Delay(1000 * 50, stoppingToken);
            }
        }
    }


}
