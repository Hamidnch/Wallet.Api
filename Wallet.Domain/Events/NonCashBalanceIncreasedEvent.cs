using Wallet.Domain.Common;
using Wallet.Domain.Enums;

namespace Wallet.Domain.Events;

public class NonCashBalanceIncreasedEvent : BaseEvent
{
    public Guid WalletId { get; }
    public decimal Amount { get; }
    public NonCashSource NonCashSource { get; set; }

    public NonCashBalanceIncreasedEvent(Guid walletId, PositiveMoney amount, NonCashSource nonCashSource)
    {
        WalletId = walletId;
        Amount = amount.ToDecimal;
        NonCashSource = nonCashSource;
    }
}