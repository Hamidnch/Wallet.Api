using Wallet.Domain.Common;
using Wallet.Domain.Enums;

namespace Wallet.Domain.ValueObjects;

public class TransactionWallet : ValueObject<TransactionWallet>
{
    public TransactionType Type { get; private set; }
    public DateTime LastUpdated { get; private set; }
    public PositiveMoney Amount { get; private set; }
    public NonCashSource NonCashSource { get; private set; }

    public TransactionWallet(TransactionType type,
        PositiveMoney amount, DateTime lastUpdated,
        NonCashSource nonCashSource = NonCashSource.Others)
    {
        Type = type;
        Amount = amount;
        NonCashSource = nonCashSource;
        LastUpdated = lastUpdated;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Type;
        yield return Amount;
        yield return NonCashSource;
        yield return LastUpdated;
    }
}