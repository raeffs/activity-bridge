using Raeffs.ActivityBridge.Entities;

namespace Raeffs.ActivityBridge.ModelBuilders;

internal interface IReferenceBuilder
{
    Uri ForActor(Actor actor);
}
