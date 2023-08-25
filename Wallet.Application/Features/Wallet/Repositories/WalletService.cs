using MediatR;
using Wallet.Application.Features.Wallet.Services;
using Wallet.Domain.Common;
using Wallet.Domain.Enums;

namespace Wallet.Application.Features.Wallet.Repositories;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<Domain.Entities.Wallet> GetByUserIdAsync(Guid userId)
    {
        return await _walletRepository.GetByUserIdAsync(userId);
    }

    public async Task<Unit> IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount)
    {
        var wallet = await _walletRepository.GetByUserIdAsync(userId);
        wallet.IncreaseCash(amount);
        await _walletRepository.UpdateAsync(wallet);

        return Unit.Value;
    }

    public async Task<Unit> IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource)
    {
        var wallet = await _walletRepository.GetByUserIdAsync(userId);
        wallet.IncreaseNonCash(amount, nonCashSource);
        await _walletRepository.UpdateAsync(wallet);

        return Unit.Value;
    }

    public async Task<Unit> DecreaseCashBalanceAsync(Guid userId, PositiveMoney amount)
    {
        var wallet = await _walletRepository.GetByUserIdAsync(userId);
        wallet.DecreaseCash(amount);
        await _walletRepository.UpdateAsync(wallet);

        return Unit.Value;
    }

    public async Task<Unit> IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount)
    {
        var wallet = await _walletRepository.GetByUserIdAsync(userId);
        wallet.IncreaseCashFromReturn(amount);
        await _walletRepository.UpdateAsync(wallet);

        return Unit.Value;
    }
}