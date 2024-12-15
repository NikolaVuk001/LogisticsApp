using LogisticsApp.Domain.Entites;

namespace LogisticsApp.Domain.Interfaces;

public interface IShipmentRepository
{
    public void Create(Shipment shipment);
    public IEnumerable<Shipment> GetAll();
    public Shipment FindById(Guid id);
    public void Update(Shipment shipment);
    public void Remove(Guid id);
}