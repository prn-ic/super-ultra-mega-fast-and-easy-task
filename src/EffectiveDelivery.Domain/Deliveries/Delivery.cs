using EffectiveDelivery.Domain.Common;
using EffectiveDelivery.Domain.Exceptions;
using EffectiveDelivery.Domain.ValueObjects;

namespace EffectiveDelivery.Domain.Deliveries;

public class Delivery : BaseEntity<int>
{
    public double Weight { get; private set; }
    public virtual Address Address { get; private set; }
    public DateTime DeliveryTime { get; private set; }
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
    protected Delivery() { }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
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
