using System.ComponentModel.DataAnnotations;

namespace Wallet.Common.Enums;

public enum TransactionType : byte
{
    None,
    [Display(Name = "افزایش نقدی")]
    CashIncrease,
    [Display(Name = "افزایش غیرنقدی")]
    NonCashIncrease,
    [Display(Name = "برداشت نقدی")]
    CashDecrease,
    [Display(Name = "افزایش نقدی حاصل از برگشت پول سفارش")]
    CashIncreaseFromReturn
}