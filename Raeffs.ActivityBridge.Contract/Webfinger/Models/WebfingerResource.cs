namespace Raeffs.ActivityBridge.Webfinger.Models;

public record WebfingerResource
{
    public required string Subject { get; init; }
    public IEnumerable<ResourceLink> Links { get; init; } = Enumerable.Empty<ResourceLink>();
}
