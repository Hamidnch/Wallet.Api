using Wallet.Domain.Common;

namespace Wallet.Domain.ValueObjects;

public class InstallmentWebsite : ValueObject<InstallmentWebsite>
{
    public string? WebsiteUrl { get; private set; }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return WebsiteUrl;
    }
}