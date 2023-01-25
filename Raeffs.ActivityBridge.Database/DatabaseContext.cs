using Microsoft.EntityFrameworkCore;
using Raeffs.ActivityBridge.Configurations;
using Raeffs.ActivityBridge.Entities;

namespace Raeffs.ActivityBridge;

internal class DatabaseContext : DbContext, IDatabaseContext, IMigrateContextOnStartup
{
    private readonly IEnumerable<IEntityTypeConfiguration> configurations;

    public DatabaseContext(
        DbContextOptions options,
        IEnumerable<IEntityTypeConfiguration> configurations
    )
        : base(options)
    {
        this.configurations = configurations;
    }

    public DbSet<ActorEntity> Actors => Set<ActorEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var configuration in configurations)
        {
            configuration.Configure(modelBuilder);
        }
    }
}
