using Flurl;
using Microsoft.Extensions.Options;
using Raeffs.ActivityBridge.Entities;
using Raeffs.ActivityBridge.Options;

namespace Raeffs.ActivityBridge.ModelBuilders;

internal class ReferenceBuilder : IReferenceBuilder
{
    private readonly IOptions<ActivityBridgeOptions> options;

    public ReferenceBuilder(IOptions<ActivityBridgeOptions> options)
    {
        this.options = options;
    }

    public Uri ForActor(Actor actor) => BaseUri
        .AppendPathSegments("users", actor.Name)
        .ToUri();

    private Url BaseUri => new Uri($"https://{options.Value.Domain}")
        .ResetToRoot()
        .AppendPathSegment("api");
}
