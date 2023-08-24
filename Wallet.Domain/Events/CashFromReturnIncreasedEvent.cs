using Wallet.Domain.Common;

namespace Wallet.Domain.Events;

public class CashFromReturnIncreasedEvent : BaseEvent
{
    public Guid WalletId { get; }
    public decimal Amount { get; }

    public CashFromReturnIncreasedEvent(Guid walletId, PositiveMoney amount)
    {
        WalletId = walletId;
        Amount = amount.ToDecimal;
    }
}