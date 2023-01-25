namespace Raeffs.ActivityBridge.Entities;

public record ActorEntity
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }
}
