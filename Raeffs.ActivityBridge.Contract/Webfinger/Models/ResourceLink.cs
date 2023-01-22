namespace Raeffs.ActivityBridge.Webfinger.Models;

public record ResourceLink
{
    public required string Rel { get; init; }
    public required string Type { get; init; }
    public required Uri Href { get; init; }
}
