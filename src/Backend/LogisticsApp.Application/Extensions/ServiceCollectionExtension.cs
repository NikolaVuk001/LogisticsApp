using LogisticsApp.Application.Interfaces;
using LogisticsApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using LogisticsApp.Application.Validators;

namespace LogisticsApp.Application.Extensions;

public static class ServiceCollectionExtension
{

    public static void AddApplication(this IServiceCollection services)
    {
        var appAssembly = typeof(ServiceCollectionExtension).Assembly;

        services.AddScoped<IShipmentService, ShipmentService>();

        services.AddAutoMapper(appAssembly);




        services.AddValidatorsFromAssemblyContaining<CreateShipmentDtoValidator>();

    }
}