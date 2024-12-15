using LogisticsApp.Domain.Entites;
using LogisticsApp.Domain.Enums;

namespace LogisticsApp.Infrastructure.Persistance;

public class MockDatabase
{
    private readonly Dictionary<Guid, Shipment> _shipments = [];



    public Dictionary<Guid, Shipment> Shipments => _shipments;


}