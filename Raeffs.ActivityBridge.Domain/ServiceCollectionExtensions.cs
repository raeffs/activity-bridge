using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Raeffs.ActivityBridge.ModelBuilders;

namespace Raeffs.ActivityBridge;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddTransient<IActorBuilder, ActorBuilder>();
    }
}
