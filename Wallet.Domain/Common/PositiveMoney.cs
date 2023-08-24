using Wallet.Domain.Common.Exceptions;

namespace Wallet.Domain.Common
{
    public readonly struct PositiveMoney
    {
        private readonly Money _money;

        /// <summary>
        /// Initializes a new instance of the <see cref="PositiveMoney"/> struct.
        /// </summary>
        /// <param name="value">Decimal amount.</param>
        public PositiveMoney(decimal value)
        {
            if (value < 0)
                throw new MoneyShouldBePositiveException("The 'Amount' should be positive.");

            _money = new Money(value);
        }

        /// <summary>
        /// Converts into Money Value Object.
        /// </summary>
        /// <returns>Money.</returns>
        public Money ToMoney() => _money;

        public decimal ToDecimal => _money.ToDecimal();

        internal PositiveMoney Add(PositiveMoney positiveAmount)
        {
            return _money.Add(positiveAmount._money);
        }

        internal Money Subtract(PositiveMoney positiveAmount)
        {
            return _money.Subtract(positiveAmount._money);
        }

        public override string ToString()
        {
            return _money.ToString();
        }
    }
}