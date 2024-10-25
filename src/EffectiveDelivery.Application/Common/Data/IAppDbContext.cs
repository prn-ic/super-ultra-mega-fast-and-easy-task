using EffectiveDelivery.Domain.Deliveries;
using Microsoft.EntityFrameworkCore;

namespace EffectiveDelivery.Application.Common.Data;

public interface IAppDbContext
{
    DbSet<Delivery> Deliveries { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
