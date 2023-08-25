using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Domain.Common;
using Wallet.Domain.Entities;
using Wallet.Domain.Enums;

namespace Wallet.Persistence.Repositories;

public class WalletRepository : IWalletRepository
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Domain.Entities.Wallet> _walletRepository;

    public WalletRepository(
        IRepository<User> userRepository,
        IRepository<Domain.Entities.Wallet> walletRepository)
    {
        _walletRepository = walletRepository;
        _userRepository = userRepository;
    }

    public async Task<Domain.Entities.Wallet> GetByIdAsync(Guid id)
    {
        var wallet = await _walletRepository.GetByIdAsync(id)
                   ?? throw new Exception("user is null");

        return wallet;
    }

    public async Task<Domain.Entities.Wallet> GetByUserIdAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId)
                   ?? throw new Exception("user is null");

        return user.Wallet;
    }

    public async Task AddAsync(Domain.Entities.Wallet wallet)
    {
        await _walletRepository.AddAsync(wallet);
    }

    public async Task UpdateAsync(Domain.Entities.Wallet wallet)
    {
        await _walletRepository.UpdateAsync(wallet);
    }

    public async Task DeleteAsync(Guid id)
    {
        var wallet = await _walletRepository.GetByIdAsync(id);

        if (wallet is not null)
        {
            await _walletRepository.DeleteAsync(wallet);
        }
    }

    public async Task IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount)
    {
        var wallet = await GetByUserIdAsync(userId);
        wallet.IncreaseCash(amount);
        await _walletRepository.UpdateAsync(wallet);
    }

    public async Task IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource)
    {
        var wallet = await GetByUserIdAsync(userId);
        wallet.IncreaseNonCash(amount, nonCashSource);
        await _walletRepository.UpdateAsync(wallet);
    }

    public async Task DecreaseCashBalanceAsync(Guid userId, PositiveMoney amount)
    {
        var wallet = await GetByUserIdAsync(userId);
        wallet.DecreaseCash(amount);
        await _walletRepository.UpdateAsync(wallet);
    }

    public async Task IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount)
    {
        var wallet = await GetByUserIdAsync(userId);
        wallet.IncreaseCashFromReturn(amount);
        await _walletRepository.UpdateAsync(wallet);
    }
}