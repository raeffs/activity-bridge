using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Raeffs.ActivityBridge;

internal interface IMigrateContextOnStartup
{
    public DatabaseFacade Database { get; }
}
