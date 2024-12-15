using AutoMapper;
using LogisticsApp.Application.Dtos;
using LogisticsApp.Domain.Common;
using LogisticsApp.Domain.Entites;
using LogisticsApp.Domain.Enums;

namespace LogisticsApp.Application.Profiles;

public class ShipmentProfile : Profile
{
    public ShipmentProfile()
    {
        CreateMap<CreateShipmentDto, Shipment>()
        .ForMember(
            dest => dest.Status,
            opt => opt.MapFrom(
                src => src.ShipmentStatus != null
                ? ShipmentStatusConverter.FromString(src.ShipmentStatus)
                : ShipmentStatus.InWarehouse));

        CreateMap<Shipment, ShipmentDto>()
        .ForMember(
            dest => dest.ShipmentStatus,
            opt => opt.MapFrom(src => src.Status.GetShipmentStatusMessage())
        );
    }
}