using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Raeffs.ActivityBridge.Configurations;

namespace Raeffs.ActivityBridge;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string? connectionString)
    {
        ArgumentException.ThrowIfNullOrEmpty(connectionString);

        return services
            .AddDbContext<IDatabaseContext, DatabaseContext>(options => options
                .UseNpgsql(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            )
            .AddEntityTypeConfigurations()
            .EnableMigrationOnStartupFor<DatabaseContext>()
            .AddTransient<IDatabaseInitializer, DatabaseInitializer>();
    }

    private static IServiceCollection AddEntityTypeConfigurations(this IServiceCollection services)
    {
        var entityTypeConfigurations = typeof(DatabaseContext).Assembly.DefinedTypes
            .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && typeof(IEntityTypeConfiguration).IsAssignableFrom(t));

        foreach (var type in entityTypeConfigurations)
        {
            services.AddTransient(typeof(IEntityTypeConfiguration), type);
        }

        return services;
    }

    private static IServiceCollection EnableMigrationOnStartupFor<TContext>(this IServiceCollection services)
        where TContext : IMigrateContextOnStartup
    {
        return services.AddScoped<IMigrateContextOnStartup>(services => services.GetRequiredService<TContext>());
    }
}
