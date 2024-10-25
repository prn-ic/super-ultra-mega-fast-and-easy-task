using System.Reflection;
using EffectiveDelivery.Application.Common.Data;
using EffectiveDelivery.Domain.Deliveries;
using Microsoft.EntityFrameworkCore;

namespace EffectiveDelivery.Infrastructure.Data;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<Delivery> Deliveries => Set<Delivery>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
