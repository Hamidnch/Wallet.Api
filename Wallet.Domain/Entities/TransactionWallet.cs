using Wallet.Common.Enums;
using Wallet.Domain.Common;
using Wallet.Domain.Events;

namespace Wallet.Domain.Entities;

public class TransactionWallet : AggregateRoot //: ValueObject<TransactionWallet>
{
    public TransactionType Type { get; private set; }
    public DateTime LastUpdated { get; private set; }
    public decimal Amount { get; private set; }
    public NonCashSource NonCashSource { get; private set; }

    //public Entities.Wallet Wallet { get; set; } = new Entities.Wallet();

    public TransactionWallet(TransactionType type,
        decimal amount, DateTime lastUpdated,
        NonCashSource nonCashSource = NonCashSource.Others)
    {
        Type = type;
        Amount = amount;
        NonCashSource = nonCashSource;
        LastUpdated = lastUpdated;
    }

    //protected override IEnumerable<object> GetEqualityComponents()
    //{
    //    yield return Type;
    //    yield return Amount;
    //    yield return NonCashSource;
    //    yield return LastUpdated;
    //}

    public override void AddEvent(BaseEvent domainEvent)
    {
        throw new NotImplementedException();
    }
}