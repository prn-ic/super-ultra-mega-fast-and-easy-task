using EffectiveDelivery.Domain.Common;

namespace EffectiveDelivery.Domain.Exceptions;

public class InvalidAddressException : DomainException
{
    public override string Message => "Ошибка в создании адреса. Проверьте правильность полей";
}