using System.Text.Json;
using Flurl;
using KristofferStrube.ActivityStreams;
using KristofferStrube.ActivityStreams.JsonLD;
using Microsoft.Extensions.Options;
using Raeffs.ActivityBridge.Entities;
using Raeffs.ActivityBridge.Options;

namespace Raeffs.ActivityBridge.ModelBuilders;

internal class ActorBuilder : IActorBuilder
{
    private readonly IOptions<ActivityBridgeOptions> options;

    public ActorBuilder(IOptions<ActivityBridgeOptions> options)
    {
        this.options = options;
    }

    public Actor GetActor(ActorEntity source) => new()
    {
        JsonLDContext = new List<ReferenceTermDefinition>() { new(new("https://www.w3.org/ns/activitystreams")) },
        Id = GetId(source).ToString(),
        Type = new List<string>() { "Person" },
        PreferredUsername = source.Name,
        Inbox = GetInbox(source).AsLink(),
        Outbox = GetOutbox(source).AsLink(),
        Followers = GetFollowers(source).AsLink(),
        Following = GetFollowing(source).AsLink(),
        ExtensionData = new()
        {
            { "manuallyApprovesFollowers", JsonSerializer.SerializeToElement(false) },
            { "discoverable", JsonSerializer.SerializeToElement(true) },
        }
    };

    public Uri GetId(ActorEntity source) => BaseUri
        .AppendPathSegments("actors", source.Name)
        .ToUri();

    public Uri GetInbox(ActorEntity source) => BaseUri
        .AppendPathSegments("inbox", source.Name)
        .ToUri();

    public Uri GetOutbox(ActorEntity source) => BaseUri
        .AppendPathSegments("outbox", source.Name)
        .ToUri();

    public Uri GetFollowers(ActorEntity source) => BaseUri
        .AppendPathSegments("followers", source.Name)
        .ToUri();

    public Uri GetFollowing(ActorEntity source) => BaseUri
        .AppendPathSegments("following", source.Name)
        .ToUri();

    private Uri BaseUri => new Uri($"https://{options.Value.Domain}")
        .ResetToRoot()
        .AppendPathSegment("api")
        .ToUri();
}
