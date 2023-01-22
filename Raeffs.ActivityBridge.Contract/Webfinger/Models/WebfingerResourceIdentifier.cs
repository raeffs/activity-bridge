using System.Diagnostics.CodeAnalysis;

namespace Raeffs.ActivityBridge.Webfinger.Models;

public record WebfingerResourceIdentifier
{
    public required string User { get; init; }
    public required string Domain { get; init; }

    public override string ToString() => $"acct:{User}@{Domain}";

    public static bool TryParse(string value, [NotNullWhen(true)] out WebfingerResourceIdentifier? model)
    {
        model = null;

        if (!value.StartsWith("acct:"))
        {
            return false;
        }

        var parts = value.Replace("acct:", string.Empty).Split("@");
        if (parts.Length != 2)
        {
            return false;
        }

        var user = parts[0].Trim();
        if (string.IsNullOrWhiteSpace(user))
        {
            return false;
        }

        var domain = parts[1].Trim();
        if (string.IsNullOrWhiteSpace(domain))
        {
            return false;
        }

        model = new()
        {
            User = user,
            Domain = domain
        };

        return true;
    }
}
