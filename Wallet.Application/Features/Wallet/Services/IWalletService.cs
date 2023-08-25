using MediatR;
using Wallet.Domain.Common;
using Wallet.Domain.Enums;

namespace Wallet.Application.Features.Wallet.Services;

public interface IWalletService
{
    Task<Domain.Entities.Wallet> GetByUserIdAsync(Guid userId);
    Task<Unit> IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount);
    Task<Unit> IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource);
    Task<Unit> DecreaseCashBalanceAsync(Guid userId, PositiveMoney amount);
    Task<Unit> IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount);
}