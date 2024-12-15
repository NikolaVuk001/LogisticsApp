using FluentValidation;
using LogisticsApp.Application.Dtos;
using LogisticsApp.API.Filters;
using LogisticsApp.Application.Interfaces;

namespace LogisticsApp.API.Endpoints;

public static class ShipmentEndpoints
{
    public static void AddShipmentEndpoints(this WebApplication app)
    {
        // CREATE NEW SHIPMENT ENDPOINT
        // ----------------------------
        app.MapPost("/api/shipments", (
            CreateShipmentDto createShipmentDto,
            IShipmentService shipmentService
            ) =>
        {
            var shipmentDto = shipmentService.CreateNewShipment(createShipmentDto);
            return Results.Created($"/api/shipments/{shipmentDto.Id}", shipmentDto);

        })
        .WithSummary("Create New Shippment")
        .AddEndpointFilter<ValidationFilter<CreateShipmentDto>>()
        .WithName("CreateNewShippment")
        .WithOpenApi();



        // GET ALL SHIPMENTS ENPOINT
        // ----------------------------
        app.MapGet("/api/shipments", (IShipmentService shipmentService) =>
        {
            var shipments = shipmentService.GetAllShipments();

            return Results.Ok(shipments);

        })
        .WithSummary("Getting All The Shipments")
        .WithName("GetAllShipments")
        .WithOpenApi();



        // UPDATE SHIPMENTS ENPOINT
        // ----------------------------
        app.MapPut("/api/shipments", (
            UpdateShipmentDto updateShipmentDto,
            IShipmentService shipmentService
        ) =>
        {
            var updatedShipment = shipmentService.UpdateShipment(updateShipmentDto);
            return Results.Created($"/api/shipments/{updatedShipment.Id}", updatedShipment);
        })
        .WithSummary("Update an Existing Shipment.")
        .AddEndpointFilter<ValidationFilter<UpdateShipmentDto>>()
        .WithName("UpdateShipment")
        .WithOpenApi();



        // DELETE SHIPMENT ENDPOINT
        // ----------------------------
        app.MapDelete("api/shipments/{id}", (
            Guid id,
            IShipmentService shipmentService
        ) =>
        {
            shipmentService.DeleteShipment(id);

            return Results.NoContent();
        })
        .WithSummary("Delete Shipment")
        .WithName("DeleteShipment")
        .WithOpenApi();

        app.MapGet("/api/shipments/{id}", (
            Guid id,
            IShipmentService shipmentService
        ) =>
        {
            var shipment = shipmentService.GetShipmentById(id);
            return Results.Ok(shipment);

        })
        .WithSummary("Get Shipment By Id")
        .WithName("GetShipmentById")
        .WithOpenApi();
    }
}

