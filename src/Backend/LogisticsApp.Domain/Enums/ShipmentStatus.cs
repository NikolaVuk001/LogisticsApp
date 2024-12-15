using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LogisticsApp.Domain.Enums;

public enum ShipmentStatus
{
    InTransit,
    Delivered,
    InWarehouse

}