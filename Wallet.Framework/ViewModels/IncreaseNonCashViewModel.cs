using Wallet.Common.Enums;

namespace Wallet.Framework.ViewModels;
public record IncreaseNonCashViewModel(Guid UserId, decimal Amount, NonCashSource NonCashSource);