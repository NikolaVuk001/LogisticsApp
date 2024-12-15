using LogisticsApp.Domain.Interfaces;
using LogisticsApp.Infrastructure.Persistance;
using LogisticsApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LogisticsApp.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IShipmentRepository, ShipmentRepository>();

        services.AddSingleton<MockDatabase>();
    }
}