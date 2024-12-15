using LogisticsApp.Domain.Enums;

namespace LogisticsApp.Domain.Entites;

public class Shipment
{
    public Guid Id { get; set; }
    public string Naziv { get; set; } = default!;
    public ShipmentStatus Status { get; set; } = ShipmentStatus.InWarehouse;
    public DateTime DatumKreiranja { get; set; }
    public DateTime? DatumIsporuke { get; set; }
}