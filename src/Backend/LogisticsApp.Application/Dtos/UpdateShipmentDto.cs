using LogisticsApp.Domain.Enums;

namespace LogisticsApp.Application.Dtos;

public class UpdateShipmentDto(Guid id, string? naziv, string? status, DateTime? datumIsporuke)
{
    public Guid Id { get; set; } = id;
    public string? Naziv { get; set; } = naziv;
    public string? Status { get; set; } = status;
    public DateTime? DatumIsporuke { get; set; } = datumIsporuke;
}