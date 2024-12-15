namespace LogisticsApp.Application.Dtos;

public class CreateShipmentDto
{
    public required string Naziv { get; set; }
    public string? ShipmentStatus { get; set; }
    public DateTime? DatumIsporuke { get; set; }
}