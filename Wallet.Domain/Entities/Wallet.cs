using Wallet.Common.Enums;
using Wallet.Domain.Common;
using Wallet.Domain.Events;

namespace Wallet.Domain.Entities
{
    public class Wallet : AggregateRoot
    {
        private readonly List<TransactionWallet> _transactions = new List<TransactionWallet>();

        /// <summary>
        /// صندوق وجه حاصل از پرداخت نقدی
        /// </summary>
        public decimal CashBalance { get; private set; }
        /// <summary>
        /// صندوق وجه حاصل از پرداخت غیرنقدی
        /// </summary>
        public decimal NonCashBalance { get; private set; }

        /// <summary>
        /// تراکنشهای مربوط به کیف پول
        /// </summary>
        public IReadOnlyCollection<TransactionWallet> Transactions => _transactions.AsReadOnly();

        /// <summary>
        /// کاربر مالک کیف پول
        /// </summary>
        public User? User { get; set; }
        public Guid UserId { get; set; }

        /// <summary>
        /// افزایش مستقیم نقدی
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Wallet IncreaseCash(decimal amount)
        {
            CashBalance += amount;
            var transaction =
                new TransactionWallet(TransactionType.CashIncrease, amount, DateTime.UtcNow);
            _transactions.Add(transaction);

            return this;
        }

        /// <summary>
        /// افزایش غیر نقدی از طریق کد هدیه یا معرف یا سایتهای اقساطی
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="nonCashSource"></param>
        /// <returns></returns>
        public Wallet IncreaseNonCash(decimal amount, NonCashSource nonCashSource)
        {
            NonCashBalance += amount;

            var transaction =
                new TransactionWallet(TransactionType.NonCashGiftCodeIncrease, amount, DateTime.UtcNow, nonCashSource);
            _transactions.Add(transaction);

            return this;
        }

        /// <summary>
        /// برداشت وجه نقدی
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Wallet WithdrawCash(decimal amount)
        {
            if (amount > CashBalance)
                throw new InvalidOperationException("Insufficient cash balance");

            CashBalance -= Math.Abs(amount);

            var transaction =
                new TransactionWallet(TransactionType.CashDecrease, amount, DateTime.UtcNow);
            _transactions.Add(transaction);

            return this;
        }

        /// <summary>
        /// از طریق برگشت پول سفارش
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Wallet IncreaseCashFromReturn(decimal amount)
        {
            CashBalance += amount;

            var transaction =
                new TransactionWallet(TransactionType.CashIncreaseFromReturn, amount, DateTime.UtcNow);
            _transactions.Add(transaction);

            return this;
        }

        public override void AddEvent(BaseEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}