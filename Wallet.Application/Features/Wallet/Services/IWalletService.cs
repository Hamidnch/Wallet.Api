using MediatR;
using Wallet.Common.Enums;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Services;

public interface IWalletService
{
    Task<Domain.Entities.Wallet?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);

    Task<Unit> IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken);
    Task<Unit> IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource, CancellationToken cancellationToken);
    Task<Unit> DecreaseCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken);
    Task<Unit> IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken);
}