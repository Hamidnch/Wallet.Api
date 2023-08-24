using Wallet.Domain.Common;

namespace Wallet.Domain.Events
{
    public class CashBalanceIncreasedEvent : BaseEvent
    {
        public Guid WalletId { get; }
        public decimal Amount { get; }

        public CashBalanceIncreasedEvent(Guid walletId, PositiveMoney amount)
        {
            WalletId = walletId;
            Amount = amount.ToDecimal;
        }
    }
}