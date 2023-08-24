﻿using Wallet.Domain.Common;
using Wallet.Domain.Events;

namespace Wallet.Domain.Entities
{
    public class User : AggregateRoot
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public MobileNumber MobileNumber { get; set; }
        public Wallet Wallet { get; private set; } = new Wallet();

        public override void AddEvent(BaseEvent domainEvent)
        {
            if (domainEvent is WalletTransactionAddedEvent walletTransactionAddedEvent)
            {
                // Handle the event and update the entity state accordingly
            }
        }
    }
}