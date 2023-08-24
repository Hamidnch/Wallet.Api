using Wallet.Domain.Common;
using Wallet.Domain.Enums;
using Wallet.Domain.Events;

namespace Wallet.Domain.Entities
{
    public class Wallet : AggregateRoot
    {
        public PositiveMoney CashBalance { get; private set; } = new PositiveMoney(0);
        public PositiveMoney NonCashBalance { get; private set; } = new PositiveMoney(0);

        private readonly List<TransactionWallet> _transactions = new List<TransactionWallet>();

        public IReadOnlyList<TransactionWallet> Transactions => _transactions.AsReadOnly();

        public TransactionWallet IncreaseCash(PositiveMoney amount)
        {
            CashBalance.Add(amount);
            var transaction = new TransactionWallet(TransactionType.CashIncrease, amount, DateTime.UtcNow);
            _transactions.Add(transaction);

            return transaction;
        }

        public TransactionWallet IncreaseNonCash(PositiveMoney amount, NonCashSource nonCashSource)
        {
            NonCashBalance.Add(amount);

            var transaction = new TransactionWallet(TransactionType.NonCashIncrease, amount, DateTime.UtcNow, nonCashSource);
            _transactions.Add(transaction);

            return transaction;
        }

        public TransactionWallet DecreaseCash(PositiveMoney amount)
        {
            if (amount.ToDecimal > CashBalance.ToDecimal)
                throw new InvalidOperationException("Insufficient cash balance");

            var money = new PositiveMoney(Math.Abs(amount.ToDecimal));
            CashBalance.Subtract(money);

            var transaction = new TransactionWallet(TransactionType.CashDecrease, amount, DateTime.UtcNow);
            _transactions.Add(transaction);

            return transaction;
        }

        public TransactionWallet IncreaseCashFromReturn(PositiveMoney amount)
        {
            CashBalance.Add(amount);

            var transaction = new TransactionWallet(TransactionType.CashIncreaseFromReturn, amount, DateTime.UtcNow);
            _transactions.Add(transaction);

            return transaction;
        }

        public override void AddEvent(BaseEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}