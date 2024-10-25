using FluentValidation;

namespace EffectiveDelivery.Application.Deliveries.Queries.GetDeliveries;

public class GetDeliveriesQueryValidation : AbstractValidator<GetDeliveriesQuery>
{
    public GetDeliveriesQueryValidation()
    {
        RuleFor(x => x.Filter)
            .NotEmpty()
            .NotNull();
    }
}