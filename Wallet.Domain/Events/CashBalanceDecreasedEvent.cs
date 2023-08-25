using Wallet.Domain.Common;

namespace Wallet.Domain.Events;

public class CashBalanceDecreasedEvent : BaseEvent
{
    public Guid UserId { get; }
    public decimal Amount { get; }

    public CashBalanceDecreasedEvent(Guid userId, PositiveMoney amount)
    {
        UserId = userId;
        Amount = amount.ToDecimal;
    }
}