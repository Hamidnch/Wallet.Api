using Wallet.Domain.Common;
using Wallet.Domain.Enums;

namespace Wallet.Application.Features.Wallet.Repositories;

public interface IWalletRepository
{
    Task<Domain.Entities.Wallet> GetByIdAsync(Guid id);
    Task<Domain.Entities.Wallet> GetByUserIdAsync(Guid userId);
    Task AddAsync(Domain.Entities.Wallet wallet);
    Task UpdateAsync(Domain.Entities.Wallet wallet);
    Task DeleteAsync(Guid id);

    Task IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount);
    Task IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource);
    Task DecreaseCashBalanceAsync(Guid userId, PositiveMoney amount);
    Task IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount);
}