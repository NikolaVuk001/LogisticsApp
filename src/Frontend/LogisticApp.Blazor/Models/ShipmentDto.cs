namespace LogisticsApp.Blazor.Models;

public class ShipmentDto
{
    public Guid Id { get; set; }
    public string Naziv { get; set; } = default!;
    public string ShipmentStatus { get; set; } = default!;
    public DateTime DatumKreiranja { get; set; }
    public DateTime? DatumIsporuke { get; set; }
}