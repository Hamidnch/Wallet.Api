using Microsoft.EntityFrameworkCore;
using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Common.Enums;
using Wallet.Domain.Common;
using Wallet.Persistence.Context;

namespace Wallet.Persistence.Repositories;

public class WalletRepository : Repository<Domain.Entities.Wallet>, IWalletRepository
{
    public WalletRepository(WalletDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<Domain.Entities.Wallet?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var wallet = await Entities
            .Where(w => w.UserId == userId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return wallet;
    }

    public async Task IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken)
    {
        var wallet = await GetByUserIdAsync(userId, cancellationToken);

        if (wallet is not null)
        {
            wallet = wallet.IncreaseCash(amount.ToDecimal);
            await UpdateAsync(wallet);
        }
    }

    public async Task IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource, CancellationToken cancellationToken)
    {
        var wallet = await GetByUserIdAsync(userId, cancellationToken);

        if (wallet is not null)
        {
            wallet = wallet.IncreaseNonCash(amount.ToDecimal, nonCashSource);
            await UpdateAsync(wallet);
        }
    }

    public async Task IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken)
    {
        var wallet = await GetByUserIdAsync(userId, cancellationToken);

        if (wallet is not null)
        {
            wallet = wallet.IncreaseCashFromReturn(amount.ToDecimal);
            await UpdateAsync(wallet);
        }
    }

    public async Task WithdrawCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken)
    {
        var wallet = await GetByUserIdAsync(userId, cancellationToken);

        if (wallet is not null)
        {
            wallet = wallet.WithdrawCash(amount.ToDecimal);
            await UpdateAsync(wallet);
        }
    }
}