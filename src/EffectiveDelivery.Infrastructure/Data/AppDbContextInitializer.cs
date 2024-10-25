using EffectiveDelivery.Domain.Deliveries;
using EffectiveDelivery.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace EffectiveDelivery.Infrastructure.Data;

public class AppDbContextInitializer
{
    private readonly AppDbContext _context;

    public AppDbContextInitializer(AppDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (!await _context.Deliveries.AnyAsync(cancellationToken))
        {
            await _context.Deliveries.AddRangeAsync(
                [
                    GenerateDeliveries(
                        1,
                        "city1",
                        "district1",
                        "street1",
                        "1d",
                        DateTime.Now.AddHours(1)
                    ),
                    GenerateDeliveries(
                        2,
                        "Moskow",
                        "Tereshkova",
                        "Tereshkova",
                        "1",
                        DateTime.Now.AddHours(1)
                    ),
                    GenerateDeliveries(
                        3,
                        "Moskow",
                        "Tereshkova",
                        "Tereshkova",
                        "2a",
                        DateTime.Now.AddHours(1)
                    ),
                ]
            );
        }

        await _context.SaveChangesAsync(cancellationToken);
    }

    private Delivery GenerateDeliveries(
        double weight,
        string city,
        string district,
        string street,
        string houseNumber,
        DateTime deliveryTime
    ) => new(weight, new(city, district, street, houseNumber), deliveryTime);
}
