using LogisticsApp.Domain.Entites;
using LogisticsApp.Domain.Exceptions;
using LogisticsApp.Domain.Interfaces;
using LogisticsApp.Infrastructure.Persistance;

namespace LogisticsApp.Infrastructure.Repositories;

internal class ShipmentRepository(MockDatabase db) : IShipmentRepository
{
    public void Create(Shipment shipment)
    {
        if (db.Shipments.ContainsKey(shipment.Id))
        {
            throw new EntityAlreadyExistsException(nameof(Shipment), shipment.Id.ToString());
        }

        db.Shipments[shipment.Id] = shipment;
    }

    public Shipment FindById(Guid id)
    {
        if (!db.Shipments.ContainsKey(id))
        {
            throw new EntityNotFoundException(nameof(Shipment), id.ToString());
        }
        return db.Shipments[id];
    }

    public IEnumerable<Shipment> GetAll()
    {
        return db.Shipments.Values.ToList();
    }

    public void Remove(Guid id)
    {
        db.Shipments.Remove(id);
    }

    public void Update(Shipment shipment)
    {
        db.Shipments[shipment.Id] = shipment;
    }
}
