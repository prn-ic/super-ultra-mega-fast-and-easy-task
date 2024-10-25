using AutoMapper;
using EffectiveDelivery.Application.Common.Data;
using EffectiveDelivery.Application.Deliveries.Dtos;
using EffectiveDelivery.Application.Deliveries.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EffectiveDelivery.Application.Deliveries.Queries.GetDeliveries;

public class GetDeliveriesQuery : IRequest<IEnumerable<DeliveryDto>>
{
    public required GetDeliveryFilterRequest Filter { get; set; }
}

public class GetDeliveriesQueryHandler
    : IRequestHandler<GetDeliveriesQuery, IEnumerable<DeliveryDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetDeliveriesQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DeliveryDto>> Handle(
        GetDeliveriesQuery request,
        CancellationToken cancellationToken
    )
    {
        var deliveries = await _context
            .Deliveries.Where(x =>
                x.Address.District.Equals(request.Filter.CityDistrict)
                || x.DeliveryTime >= request.Filter.FirstDeliveryDateTime
            )
            .ToListAsync();

        return _mapper.Map<IEnumerable<DeliveryDto>>(deliveries);
    }
}
