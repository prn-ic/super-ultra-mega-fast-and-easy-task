using EffectiveDelivery.Domain.Common;
using EffectiveDelivery.Domain.Exceptions;

namespace EffectiveDelivery.Domain.ValueObjects;

public class Address : ValueObject
{
    public string District { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string HouseNumber { get; private set; }

    public Address(string city, string district, string street, string houseNumber)
    {
        GuardException.ThrowIfInvalidAddress(city);
        GuardException.ThrowIfInvalidAddress(district);
        GuardException.ThrowIfInvalidAddress(street);
        GuardException.ThrowIfInvalidAddress(houseNumber);
        
        City = city;
        District = district;
        Street = street;
        HouseNumber = houseNumber;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return District;
        yield return Street;
        yield return HouseNumber;
    }
}
