using Wallet.Domain.Common;

namespace Wallet.Domain.ValueObjects;

public class GiftCode : ValueObject<GiftCode>
{
    public string? Code { get; private set; }
    public bool IsUsed { get; private set; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Code;
        yield return IsUsed;
    }
}