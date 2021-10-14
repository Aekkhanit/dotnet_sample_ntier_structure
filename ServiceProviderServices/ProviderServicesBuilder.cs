using DevExpress.Xpo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ProviderServices
{
 

    public static class ProviderServicesBuilder
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICustomerServices, CustomerServices>();
            services.AddTransient<IVendorServices, VendorServices>();
            services.AddTransient<IWebhookServices, WebhookServices>();

            return services;
        }

    }
}