using System.ComponentModel.DataAnnotations;

namespace LogisticsApp.Blazor.Models;

public class CreateShipmentDto
{
    public CreateShipmentDto(string naziv, string shipmentStatus = "U Skladištu", DateTime? datumIsporuke = null)
    {
        Naziv = naziv;
        ShipmentStatus = shipmentStatus;
        DatumIsporuke = datumIsporuke;
    }

    public string Naziv { get; set; }
    public string? ShipmentStatus { get; set; } = "U Skladištu";
    public DateTime? DatumIsporuke { get; set; }
}