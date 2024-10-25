namespace EffectiveDelivery.Application.Deliveries.Dtos;

public class AddressDto
{
    public required string City { get; set; }
    public required string District { get; set; }
    public required string Street { get; set; }
    public required string HouseNumber { get; set; }
}
