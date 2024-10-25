using EffectiveDelivery.Domain.Common;

namespace EffectiveDelivery.Domain.Exceptions;

public class InvalidDeliveryWeightException : DomainException
{
    public override string Message => "Неверный вес доставки";
}