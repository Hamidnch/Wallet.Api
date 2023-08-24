using Wallet.Domain.Entities;

namespace Wallet.Domain.Events;

public class WalletTransactionAddedEvent : BaseEvent
{
    public Guid WalletId { get; private set; }
    public TransactionWallet Transaction { get; private set; }

    public WalletTransactionAddedEvent(Guid walletId, TransactionWallet transaction)
    {
        WalletId = walletId;
        Transaction = transaction;
    }
}