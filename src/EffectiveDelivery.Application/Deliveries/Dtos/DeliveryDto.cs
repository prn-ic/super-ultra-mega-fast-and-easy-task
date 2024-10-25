using EffectiveDelivery.Domain.ValueObjects;

namespace EffectiveDelivery.Application.Deliveries.Dtos;

public class DeliveryDto
{
    public double Weight { get; set; }
    public required Address Address { get; set; }
    public DateTime DeliveryTime { get; set; }
}
