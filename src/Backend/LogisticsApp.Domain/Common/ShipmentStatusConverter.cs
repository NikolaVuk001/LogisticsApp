using LogisticsApp.Domain.Enums;

namespace LogisticsApp.Domain.Common;
public static class ShipmentStatusConverter
{
    public static string GetShipmentStatusMessage(this ShipmentStatus status) =>
    status switch
    {
        ShipmentStatus.InTransit => "Na Putu",
        ShipmentStatus.Delivered => "Isporučeno",
        ShipmentStatus.InWarehouse => "U Skladištu",
        _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
    };

    public static ShipmentStatus FromString(string status) =>
    status switch
    {
        "Na Putu" => ShipmentStatus.InTransit,
        "Isporučeno" => ShipmentStatus.Delivered,
        "U Skladištu" => ShipmentStatus.InWarehouse,
        _ => throw new ArgumentException($"Invalid status value: {status}", nameof(status))
    };
}