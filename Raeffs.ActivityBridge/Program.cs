using Raeffs.ActivityBridge;
using Raeffs.ActivityBridge.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .Configure<ActivityBridgeOptions>(builder.Configuration.GetSection("ActivityBridge"));

builder.Services
    .AddControllers();

builder.Services
    .AddDomain()
    .AddDatabase(builder.Configuration.GetConnectionString("DatabaseContext"));

var app = builder.Build();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
    await initializer.InitializeDatabasesAsync();
}

await app.RunAsync();
