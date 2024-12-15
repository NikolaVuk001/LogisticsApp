using LogisticsApp.API.Endpoints;
using LogisticsApp.Domain.Entites;
using LogisticsApp.Application.Extensions;
using LogisticsApp.Infrastructure.Extensions;
using Serilog;
using LogisticsApp.API.Middlewares;
using LogisticsApp.Infrastructure.Persistance;
using Microsoft.AspNetCore.Hosting.Server.Features;

var builder = WebApplication.CreateBuilder(args);

// Access the logger


// Log that the API is starting


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});




builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
        );

builder.Services.AddScoped<ErrorHandlingMiddleware>();


builder.Services.AddApplication();
builder.Services.AddInfrastructure();



var app = builder.Build();

app.Lifetime.ApplicationStarted.Register(() =>
{
    var logger = app.Services.GetService<ILogger<Program>>();
    logger?.LogInformation("Starting Web API...");


    var address = builder.Configuration.GetValue<string>("ASPNETCORE_URLS");
    Console.WriteLine($"Application is running at: {address}");
});





app.UseCors("AllowAll");


app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.AddShipmentEndpoints();

app.Run();

