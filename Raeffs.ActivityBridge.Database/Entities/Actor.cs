namespace Raeffs.ActivityBridge.Entities;

public record Actor
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }
}
