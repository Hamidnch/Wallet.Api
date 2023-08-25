using MediatR;
using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Domain.Common;
using Wallet.Domain.Enums;

namespace Wallet.Application.Features.Wallet.Services;

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
        await _walletRepository.IncreaseCashBalanceAsync(userId, amount);

        return Unit.Value;
    }

    public async Task<Unit> IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource)
    {
        await _walletRepository.IncreaseNonCashBalanceAsync(userId, amount, nonCashSource);

        return Unit.Value;
    }

    public async Task<Unit> DecreaseCashBalanceAsync(Guid userId, PositiveMoney amount)
    {
        await _walletRepository.DecreaseCashBalanceAsync(userId, amount);

        return Unit.Value;
    }

    public async Task<Unit> IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount)
    {
        await _walletRepository.IncreaseCashFromReturnAsync(userId, amount);

        return Unit.Value;
    }
}