using AutoMapper;
using LogisticsApp.Application.Dtos;
using LogisticsApp.Application.Interfaces;
using LogisticsApp.Domain.Common;
using LogisticsApp.Domain.Entites;
using LogisticsApp.Domain.Enums;
using LogisticsApp.Domain.Interfaces;
using Microsoft.Extensions.Logging;


namespace LogisticsApp.Application.Services;

public class ShipmentService(
    ILogger<ShipmentService> logger,
    IMapper mapper,
    IShipmentRepository shipmentRepository) : IShipmentService
{
    public ShipmentDto CreateNewShipment(CreateShipmentDto createShipmentDto)
    {
        logger.LogInformation("Adding new shipment: {@shipment}", createShipmentDto);

        Shipment shipment = mapper.Map<Shipment>(createShipmentDto);
        shipment.Id = Guid.NewGuid();
        shipment.DatumKreiranja = DateTime.Now;



        shipmentRepository.Create(shipment);

        return mapper.Map<ShipmentDto>(shipment);
    }

    public void DeleteShipment(Guid id)
    {
        logger.LogInformation("Removing shipment with id: {@id}", id);

        // Checking if the shipment with given Id Exists
        _ = shipmentRepository.FindById(id);

        shipmentRepository.Remove(id);
    }

    public IEnumerable<ShipmentDto> GetAllShipments()
    {
        logger.LogInformation("Getting all shipments.");

        IEnumerable<Shipment> shipments = shipmentRepository.GetAll();

        foreach (var shipment in shipments)
        {
            Console.WriteLine(shipment.Id);
        }

        return mapper.Map<IEnumerable<ShipmentDto>>(shipments);

    }

    public ShipmentDto GetShipmentById(Guid id)
    {
        logger.LogInformation("Getting shipment with id: {@id}", id);

        var shipment = shipmentRepository.FindById(id);

        return mapper.Map<ShipmentDto>(shipment);
    }

    public ShipmentDto UpdateShipment(UpdateShipmentDto updateShipmentDto)
    {
        logger.LogInformation(
            "Updating Shipment with id: {@id}. With new values: {@UpdateShipmentDto}"
            , updateShipmentDto.Id, updateShipmentDto);

        var shipment = shipmentRepository.FindById(updateShipmentDto.Id);

        shipment.Naziv = string.IsNullOrEmpty(updateShipmentDto.Naziv) ? shipment.Naziv : updateShipmentDto.Naziv;

        if (updateShipmentDto.Status != null)
        {
            shipment.Status = ShipmentStatusConverter.FromString(updateShipmentDto.Status);
        }

        shipment.DatumIsporuke = updateShipmentDto.DatumIsporuke ?? shipment.DatumIsporuke;

        shipmentRepository.Update(shipment);

        return mapper.Map<ShipmentDto>(shipment);
    }
}