using Wallet.Domain.Common;

namespace Wallet.Domain.Events;

public class CashFromReturnIncreasedEvent : BaseEvent
{
    public Guid UserId { get; }
    public decimal Amount { get; }

    public CashFromReturnIncreasedEvent(Guid userId, PositiveMoney amount)
    {
        UserId = userId;
        Amount = amount.ToDecimal;
    }
}