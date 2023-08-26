using Wallet.Common.Enums;
using Wallet.Domain.Common;

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