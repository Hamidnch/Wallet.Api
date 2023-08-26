using System.ComponentModel.DataAnnotations;

namespace Wallet.Common.Enums;

public enum NonCashSource : byte
{
    [Display(Name = "کد هدیه")]
    GiftCode,
    [Display(Name = "معرف")]
    Referral,
    [Display(Name = "سایتهای اقساطی")]
    InstallmentsSites,
    [Display(Name = "سایر")]
    Others
}