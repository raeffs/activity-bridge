using Microsoft.EntityFrameworkCore;
using Raeffs.ActivityBridge.Entities;

namespace Raeffs.ActivityBridge;

public interface IDatabaseContext
{
    DbSet<ActorEntity> Actors { get; }
}
