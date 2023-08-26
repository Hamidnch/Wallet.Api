﻿using Wallet.Common.Enums;
using Wallet.Domain.Common;
using Wallet.Domain.Events;

namespace Wallet.Domain.Entities;

public class TransactionWallet : AggregateRoot
{
    public TransactionType Type { get; private set; }
    public DateTime LastUpdated { get; private set; }
    public decimal Amount { get; private set; }
    public NonCashSource NonCashSource { get; private set; }

    public TransactionWallet(TransactionType type,
        decimal amount, DateTime lastUpdated,
        NonCashSource nonCashSource = NonCashSource.Others)
    {
        Type = type;
        Amount = amount;
        NonCashSource = nonCashSource;
        LastUpdated = lastUpdated;
    }

    public override void AddEvent(BaseEvent domainEvent)
    {
        throw new NotImplementedException();
    }
}