using Wallet.Domain.Common;
using Wallet.Domain.Enums;

namespace Wallet.Application.Services;

public interface IWalletService
{
    Task IncreaseCashBalanceAsync(Guid walletId, PositiveMoney amount);
    Task IncreaseNonCashBalanceAsync(Guid walletId, PositiveMoney amount, NonCashSource nonCashSource);
    Task DecreaseCashBalanceAsync(Guid walletId, PositiveMoney amount);
    Task IncreaseCashFromReturnAsync(Guid walletId, PositiveMoney amount);
}