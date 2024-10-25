using EffectiveDelivery.Domain.Common;
using EffectiveDelivery.Domain.Exceptions;
using EffectiveDelivery.Domain.ValueObjects;

namespace EffectiveDelivery.Domain.Deliveries;

public class Delivery : BaseEntity<int>
{
    public double Weight { get; private set; }
    public Address Address { get; private set; }
    public DateTime DeliveryTime { get; private set; }

    public Delivery(double weight, Address address, DateTime deliveryTime)
    {
        GuardException.ThrowIfDeliveryWeightIsInvalid(weight);
        ArgumentNullException.ThrowIfNull(address, "address");

        Weight = weight;
        Address = address;
        DeliveryTime = deliveryTime.ToUniversalTime();
    }

    public void SetWeight(double weight)
    {
        GuardException.ThrowIfDeliveryWeightIsInvalid(weight);
        Weight = weight;
    }

    public void SetAddress(Address address)
    {
        ArgumentNullException.ThrowIfNull(address, "address");
        Address = address;
    }

    public void SetDeliveryTime(DateTime time)
    {
        DeliveryTime = time.ToUniversalTime();
    }
}
