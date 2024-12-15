using LogisticsApp.Application.Dtos;
using LogisticsApp.Domain.Entites;

namespace LogisticsApp.Application.Interfaces;

public interface IShipmentService
{
    public ShipmentDto CreateNewShipment(CreateShipmentDto createShipmentDto);
    public IEnumerable<ShipmentDto> GetAllShipments();
    public ShipmentDto UpdateShipment(UpdateShipmentDto updateShipmentDto);
    public void DeleteShipment(Guid id);
    public ShipmentDto GetShipmentById(Guid id);
}