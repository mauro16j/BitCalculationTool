using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BidCalculationTool.Services.Interfaces;

namespace BidCalculationTool.Services;

public static class ServiceRegistration
{
    public static IServiceCollection AddServicesRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICalculationService, CalculationService>();

        return services;
    }
}
