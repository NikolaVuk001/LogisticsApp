namespace LogisticsApp.Application.Dtos;

public class ShipmentDto(Guid id, string naziv, string status, DateTime datumKreiranja)
{
    public Guid Id { get; set; } = id;
    public string Naziv { get; set; } = naziv;
    public string ShipmentStatus { get; set; } = status;
    public DateTime DatumKreiranja { get; set; } = datumKreiranja;
    public DateTime? DatumIsporuke { get; set; }
}