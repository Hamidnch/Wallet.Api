using System.ComponentModel.DataAnnotations;

namespace Wallet.Common.Enums;

public enum TransactionType : byte
{
    None = 0,
    [Display(Name = "افزایش نقدی")]
    CashIncrease = 1,
    [Display(Name = "افزایش نقدی - برگشت پول سفارش")]
    CashIncreaseFromReturn = 2,
    [Display(Name = "افزایش غیرنقدی - کد هدیه")]
    NonCashGiftCodeIncrease = 3,
    [Display(Name = "افزایش غیرنقدی - معرف")]
    NonCashReferralIncrease = 4,
    [Display(Name = "افزایش غیرنقدی - سایتهای اقساطی")]
    NonCashInstallmentIncrease = 5,
    [Display(Name = "برداشت نقدی")]
    CashDecrease = 6

}