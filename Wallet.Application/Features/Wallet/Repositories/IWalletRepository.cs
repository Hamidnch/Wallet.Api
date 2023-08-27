using Wallet.Common.Enums;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Repositories;

public interface IWalletRepository : IRepository<Domain.Entities.Wallet>
{
    Task<Domain.Entities.Wallet?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);

    Task IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken);
    Task IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource, CancellationToken cancellationToken);
    Task IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken);
    Task WithdrawCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken);
}