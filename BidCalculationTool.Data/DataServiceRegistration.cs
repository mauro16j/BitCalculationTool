using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BidCalculationTool.Data;

public static class DataServiceRegistration
{
    public static IServiceCollection AddDataRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase(configuration.GetConnectionString("BidCalculationToolConnectionString")));

        return services;
    }
}
