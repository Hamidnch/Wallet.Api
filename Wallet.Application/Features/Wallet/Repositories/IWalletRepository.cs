using Wallet.Common.Enums;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Repositories;

public interface IWalletRepository : IRepository<Domain.Entities.Wallet>
{
    Task<Domain.Entities.Wallet?> GetByUserIdAsync(Guid userId);

    Task IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount);
    Task IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource);
    Task DecreaseCashBalanceAsync(Guid userId, PositiveMoney amount);
    Task IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount);
}