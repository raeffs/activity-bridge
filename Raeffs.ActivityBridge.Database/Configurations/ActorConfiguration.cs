using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raeffs.ActivityBridge.Entities;

namespace Raeffs.ActivityBridge.Configurations;

internal class ActorConfiguration : EntityTypeConfiguration<Actor>
{
    public override void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.HasData(new Actor()
        {
            Id = Guid.Parse("1160a7c1-d2cc-48c4-a823-b6f96973df9d"),
            Name = "bot"
        });
    }
}
