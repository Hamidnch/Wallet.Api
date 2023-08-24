using Wallet.Domain.Common;

namespace Wallet.Domain.Events;

public class CashBalanceDecreasedEvent : BaseEvent
{
    public Guid WalletId { get; }
    public decimal Amount { get; }

    public CashBalanceDecreasedEvent(Guid walletId, PositiveMoney amount)
    {
        WalletId = walletId;
        Amount = amount.ToDecimal;
    }
}