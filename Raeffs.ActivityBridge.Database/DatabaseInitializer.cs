using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Raeffs.ActivityBridge;

internal class DatabaseInitializer : IDatabaseInitializer
{
    private readonly IEnumerable<IMigrateContextOnStartup> contexts;
    private readonly ILogger<DatabaseInitializer> logger;

    public DatabaseInitializer(IEnumerable<IMigrateContextOnStartup> contexts, ILogger<DatabaseInitializer> logger)
    {
        this.contexts = contexts;
        this.logger = logger;
    }

    public async Task InitializeDatabasesAsync()
    {
        foreach (var database in contexts.Select(x => x.Database))
        {
            try
            {
                await database.MigrateAsync();
            }
            catch (Exception exception)
            {
                logger.LogCritical(exception, "Failed to apply database migrations");
                await database.EnsureDeletedAsync();
                await database.MigrateAsync();
            }
        }
    }
}
