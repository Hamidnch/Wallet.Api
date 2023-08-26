using Wallet.Common.Enums;
using Wallet.Domain.Common;
using Wallet.Domain.Events;

namespace Wallet.Domain.Entities
{
    public class Wallet : AggregateRoot
    {
        public decimal CashBalance { get; private set; } = 0;
        public decimal NonCashBalance { get; private set; } = 0;

        private readonly List<TransactionWallet> _transactions = new List<TransactionWallet>();
        public IReadOnlyCollection<TransactionWallet> Transactions => _transactions.AsReadOnly();

        public User? User { get; set; }
        public Guid UserId { get; set; }


        public Wallet IncreaseCash(decimal amount)
        {
            CashBalance += amount;
            var transaction = new TransactionWallet(TransactionType.CashIncrease, amount, DateTime.UtcNow);
            _transactions.Add(transaction);

            return this;
        }

        public Wallet IncreaseNonCash(decimal amount, NonCashSource nonCashSource)
        {
            NonCashBalance += amount;

            var transaction = new TransactionWallet(TransactionType.NonCashIncrease, amount, DateTime.UtcNow, nonCashSource);
            _transactions.Add(transaction);

            return this;
        }

        public Wallet DecreaseCash(decimal amount)
        {
            if (amount > CashBalance)
                throw new InvalidOperationException("Insufficient cash balance");

            CashBalance -= (Math.Abs(amount));

            var transaction = new TransactionWallet(TransactionType.CashDecrease, amount, DateTime.UtcNow);
            _transactions.Add(transaction);

            return this;
        }

        public Wallet IncreaseCashFromReturn(decimal amount)
        {
            CashBalance += amount;

            var transaction = new TransactionWallet(TransactionType.CashIncreaseFromReturn, amount, DateTime.UtcNow);
            _transactions.Add(transaction);

            return this;
        }

        public override void AddEvent(BaseEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}