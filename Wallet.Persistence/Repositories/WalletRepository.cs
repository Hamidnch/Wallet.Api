using Microsoft.EntityFrameworkCore;
using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Common.Enums;
using Wallet.Domain.Common;
using Wallet.Persistence.Context;

namespace Wallet.Persistence.Repositories;

public class WalletRepository : Repository<Domain.Entities.Wallet>, IWalletRepository
{
    public WalletRepository(WalletDbContext context) : base(context)
    {
    }

    public async Task<Domain.Entities.Wallet?> GetByUserIdAsync(Guid userId)
    {
        var wallet = await DbSet.Where(w => w.UserId == userId).FirstOrDefaultAsync();

        return wallet;
    }

    public async Task IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount)
    {
        var wallet = await GetByUserIdAsync(userId);

        if (wallet is not null)
        {
            wallet = wallet.IncreaseCash(amount.ToDecimal);
            await UpdateAsync(wallet);
        }
    }

    public async Task IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource)
    {
        var wallet = await GetByUserIdAsync(userId);

        if (wallet is not null)
        {
            wallet = wallet.IncreaseNonCash(amount.ToDecimal, nonCashSource);
            await UpdateAsync(wallet);
        }
    }

    public async Task DecreaseCashBalanceAsync(Guid userId, PositiveMoney amount)
    {
        var wallet = await GetByUserIdAsync(userId);

        if (wallet is not null)
        {
            wallet = wallet.DecreaseCash(amount.ToDecimal);
            await UpdateAsync(wallet);
        }
    }

    public async Task IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount)
    {
        var wallet = await GetByUserIdAsync(userId);

        if (wallet is not null)
        {
            wallet = wallet.IncreaseCashFromReturn(amount.ToDecimal);
            await UpdateAsync(wallet);
        }
    }
}