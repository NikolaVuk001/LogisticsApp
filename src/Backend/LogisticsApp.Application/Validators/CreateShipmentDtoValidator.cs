
using FluentValidation;
using LogisticsApp.Application.Dtos;

namespace LogisticsApp.Application.Validators;

public class CreateShipmentDtoValidator : AbstractValidator<CreateShipmentDto>
{
    private string[] allowedStatusList = ["Na Putu", "Isporučeno", "U Skladištu"];
    public CreateShipmentDtoValidator()
    {
        RuleFor(s => s.Naziv)
            .NotEmpty()
            .WithMessage("Polje Naziv je obavezno.");

        RuleFor(s => s.Naziv)
            .NotNull()
            .WithMessage("Polje Naziv je obavezno.");

        RuleFor(s => s.ShipmentStatus)
           .Must(value => value == null || allowedStatusList.Contains(value))
           .WithMessage($"Status može biti: [{string.Join(", ", allowedStatusList)}]");

        // U slucaju da se postavlja datum isporuke status mora biti Isporučeno
        RuleFor(s => s.DatumIsporuke)
            .GreaterThan(DateTime.Now)
            .WithMessage("Pole Datum Isporuke mora biti u buducnosti.")
            .When(s => s.DatumIsporuke.HasValue);

        RuleFor(s => s.DatumIsporuke)
            .NotNull()
            .WithMessage("Datum isporuke mora biti naveden kada je status 'Isporučeno' postaljen")
            .When(s => s.ShipmentStatus == "Isporučeno");

        RuleFor(s => s.ShipmentStatus)
            .Equal("Isporučeno")
            .WithMessage("Status mora biti 'Isporučeno' kada je Datum Isporuke postavljen.")
            .When(s => s.DatumIsporuke.HasValue);
    }
}