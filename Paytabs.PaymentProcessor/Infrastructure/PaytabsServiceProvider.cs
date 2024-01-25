using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paytabs.PaymentProcessor.Contracts;
using Paytabs.PaymentProcessor.Models;
using Paytabs.PaymentProcessor.Services;

namespace Paytabs.PaymentProcessor.Infrastructure;

public static class PaytabsServiceProvider
{
    public static IServiceCollection AddPaytabsServices(this IServiceCollection services, IConfiguration configuration)
    {
        var paytabsConfiguration = new PaytabsConfiguration();
        configuration.GetSection("PaytabsConfiguration").Bind(paytabsConfiguration);

        services.AddScoped<IPaytabsPaymentProcessor, PaytabsPaymentProcessor>();
        services.AddSingleton<PaytabsConfiguration>();

        return services;
    }

}
