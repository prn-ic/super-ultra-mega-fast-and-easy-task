using EffectiveDelivery.Application.Deliveries.Requests;
using FluentValidation;

namespace EffectiveDelivery.Application.Deliveries.Queries.GetDeliveries;

public class GetDeliveryFilterRequestValidation : AbstractValidator<GetDeliveryFilterRequest>
{
    public GetDeliveryFilterRequestValidation()
    {
        RuleFor(x => x.CityDistrict).NotNull().NotEmpty();

        RuleFor(x => x.FirstDeliveryDateTime)
            .NotNull()
            .Must(x => x.ToUniversalTime() >= DateTime.UtcNow);
    }
}
