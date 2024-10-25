using EffectiveDelivery.Application.Common.Data;
using EffectiveDelivery.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connection = configuration.GetConnectionString("Default");
        if (string.IsNullOrEmpty(connection))
            throw new InvalidDataException("Строка подключения не найдена");

        services.AddDbContext<AppDbContext>(
            (sp, o) =>
            {
                o.UseSqlite(connection);
                o.UseSnakeCaseNamingConvention();
                o.UseLazyLoadingProxies();
            }
        );

        services.AddScoped<IAppDbContext>(p => p.GetRequiredService<AppDbContext>());
        services.AddScoped<AppDbContextInitializer>();

        return services;
    }

    public static async Task InitializeDatabaseAsync(this IServiceProvider provider)
    {
        using (var scope = provider.CreateScope())
        {
            var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
            await initialiser.InitializeAsync();
            await initialiser.SeedAsync();
        }
    }
}
