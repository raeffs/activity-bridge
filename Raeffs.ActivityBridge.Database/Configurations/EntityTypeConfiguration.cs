using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Raeffs.ActivityBridge.Configurations;

internal abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>, IEntityTypeConfiguration
    where TEntity : class
{
    public void Configure(ModelBuilder modelBuilder) => Configure(modelBuilder.Entity<TEntity>());

    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
}
