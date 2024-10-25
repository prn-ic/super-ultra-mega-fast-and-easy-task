using EffectiveDelivery.Application.Deliveries.Queries.GetDeliveries;
using EffectiveDelivery.Application.Deliveries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EffectiveDelivery.WebApi.Controllers;

[ApiController]
[Route("api/deliveries")]
public class DeliveriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public DeliveriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("get-last-deliveries")]
    public async Task<IActionResult> GetLastDeliveries(
        GetDeliveryFilterRequest request,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.Send(
            new GetDeliveriesQuery() { Filter = request },
            cancellationToken
        );
        return Ok(result);
    }
}
