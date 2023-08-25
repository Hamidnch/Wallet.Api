using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Domain.Common;
using Wallet.Domain.Entities;
using Wallet.Domain.Enums;
using Wallet.Persistence.Context;

namespace Wallet.Persistence.Repositories;

public class WalletRepository : Repository<Domain.Entities.Wallet>, IWalletRepository
{
    public WalletRepository(WalletDbContext context) : base(context)
    {
    }

    public async Task<Domain.Entities.Wallet> GetByUserIdAsync(Guid userId)
    {
        var user = await Context.Set<User>().FindAsync(userId)
                   ?? throw new Exception("user is null");

        return user.Wallet;
    }

    public async Task IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount)
    {
        var wallet = await GetByUserIdAsync(userId);
        wallet.IncreaseCash(amount);
        await UpdateAsync(wallet);
    }

    public async Task IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource)
    {
        var wallet = await GetByUserIdAsync(userId);
        wallet.IncreaseNonCash(amount, nonCashSource);
        await UpdateAsync(wallet);
    }

    public async Task DecreaseCashBalanceAsync(Guid userId, PositiveMoney amount)
    {
        var wallet = await GetByUserIdAsync(userId);
        wallet.DecreaseCash(amount);
        await UpdateAsync(wallet);
    }

    public async Task IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount)
    {
        var wallet = await GetByUserIdAsync(userId);
        wallet.IncreaseCashFromReturn(amount);
        await UpdateAsync(wallet);
    }
}