using Wallet.Domain.Common;
using Wallet.Domain.Enums;

namespace Wallet.Domain.Events;

public class NonCashBalanceIncreasedEvent : BaseEvent
{
    public Guid UserId { get; }
    public decimal Amount { get; }
    public NonCashSource NonCashSource { get; set; }

    public NonCashBalanceIncreasedEvent(Guid userId, PositiveMoney amount, NonCashSource nonCashSource)
    {
        UserId = userId;
        Amount = amount.ToDecimal;
        NonCashSource = nonCashSource;
    }
}