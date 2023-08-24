using System.Globalization;

namespace Wallet.Domain.Common
{
    public readonly struct Money
    {
        private readonly decimal _money;

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> struct.
        /// </summary>
        /// <param name="value">Decimal amount.</param>
        public Money(decimal value)
        {
            _money = value;
        }

        /// <summary>
        /// Converts into decimal.
        /// </summary>
        /// <returns>decimal amount.</returns>
        public decimal ToDecimal() => _money;

        internal bool LessThan(PositiveMoney amount)
        {
            return _money < amount.ToMoney()._money;
        }

        internal bool IsZero()
        {
            return _money == 0;
        }

        internal PositiveMoney Add(Money value)
        {
            return new PositiveMoney(_money + value.ToDecimal());
        }

        internal Money Subtract(Money value)
        {
            return new Money(_money - value.ToDecimal());
        }

        public override string ToString()
        {
            return _money.ToString(CultureInfo.InvariantCulture);
        }
    }
}