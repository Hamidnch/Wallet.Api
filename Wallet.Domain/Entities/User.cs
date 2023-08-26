using Wallet.Domain.Common;

namespace Wallet.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        //public Wallet Wallet { get; private set; } = new Wallet();

        //public override void AddEvent(BaseEvent domainEvent)
        //{
        //    if (domainEvent is WalletTransactionAddedEvent walletTransactionAddedEvent)
        //    {
        //        // Handle the event and update the entity state accordingly
        //    }
        //}
    }
}