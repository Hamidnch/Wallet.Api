using Wallet.Domain.Common;

namespace Wallet.Domain.Events
{
    public class CashBalanceIncreasedEvent : BaseEvent
    {
        public Guid UserId { get; }
        public decimal Amount { get; }

        public CashBalanceIncreasedEvent(Guid userId, PositiveMoney amount)
        {
            UserId = userId;
            Amount = amount.ToDecimal;
        }
    }
}