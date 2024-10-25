using AutoMapper;
using EffectiveDelivery.Application.Deliveries.Dtos;
using EffectiveDelivery.Domain.Deliveries;
using EffectiveDelivery.Domain.ValueObjects;

namespace EffectiveDelivery.Application.Common.Mappings;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Delivery, DeliveryDto>().ReverseMap();
    }
}
