using EffectiveDelivery.Domain.Deliveries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EffectiveDelivery.Infrastructure.Data.Configurations;

public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.OwnsOne(x => x.Address).Property(x => x.City).HasColumnName("city");
        builder.OwnsOne(x => x.Address).Property(x => x.District).HasColumnName("district");
        builder.OwnsOne(x => x.Address).Property(x => x.Street).HasColumnName("street");
        builder.OwnsOne(x => x.Address).Property(x => x.HouseNumber).HasColumnName("house_number");
    }
}
