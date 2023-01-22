using Microsoft.EntityFrameworkCore;

namespace Raeffs.ActivityBridge.Configurations;

internal interface IEntityTypeConfiguration
{
    void Configure(ModelBuilder modelBuilder);
}
