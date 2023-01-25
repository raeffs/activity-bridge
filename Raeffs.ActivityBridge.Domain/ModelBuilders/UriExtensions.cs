using KristofferStrube.ActivityStreams;

namespace Raeffs.ActivityBridge.ModelBuilders;

internal static class UriExtensions
{
    public static ILink AsLink(this Uri value) => new Link { Href = value };
}
