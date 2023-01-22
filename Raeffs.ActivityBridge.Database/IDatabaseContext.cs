using Microsoft.EntityFrameworkCore;
using Raeffs.ActivityBridge.Entities;

namespace Raeffs.ActivityBridge;

public interface IDatabaseContext
{
    DbSet<Actor> Actors { get; }
}
