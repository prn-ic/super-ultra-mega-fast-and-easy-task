namespace EffectiveDelivery.Domain.Exceptions;

public static class GuardException
{
    public static void ThrowIfInvalidAddress(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new InvalidAddressException();
    }

    public static void ThrowIfDeliveryWeightIsInvalid(double weight)
    {
        if (weight < 0)
            throw new InvalidDeliveryWeightException();
    }
}