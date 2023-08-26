using Wallet.Domain.Entities;

namespace Wallet.Domain.Events;

public class WalletTransactionAddedEvent : BaseEvent
{
    public Guid UserId { get; private set; }
    public TransactionWallet Transaction { get; private set; }

    public WalletTransactionAddedEvent(Guid userId, TransactionWallet transaction)
    {
        UserId = userId;
        Transaction = transaction;
    }
}