using KristofferStrube.ActivityStreams;
using Raeffs.ActivityBridge.Entities;

namespace Raeffs.ActivityBridge.ModelBuilders;

internal interface IActorBuilder
{
    Actor GetActor(ActorEntity source);

    Uri GetId(ActorEntity source);

    Uri GetInbox(ActorEntity source);

    Uri GetOutbox(ActorEntity source);

    Uri GetFollowers(ActorEntity source);

    Uri GetFollowing(ActorEntity source);
}
