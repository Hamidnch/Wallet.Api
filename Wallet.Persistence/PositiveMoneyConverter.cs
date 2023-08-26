//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
//using Wallet.Domain.Common;

//namespace Wallet.Persistence;

//public class PositiveMoneyConverter : ValueConverter<PositiveMoney, decimal>
//{
//    public PositiveMoneyConverter(ConverterMappingHints? mappingHints = null)
//        : base(
//            // Converts PositiveMoney to decimal
//            positiveMoney => positiveMoney.ToDecimal,
//            // Converts decimal to PositiveMoney
//            value => new PositiveMoney(value),
//            mappingHints)
//    {
//    }
//}
