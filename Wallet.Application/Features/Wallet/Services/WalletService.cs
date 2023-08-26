using MediatR;
using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Common.Enums;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;

    private readonly IUserRepository _userRepository;

    public WalletService(IWalletRepository walletRepository, IUserRepository userRepository)
    {
        _walletRepository = walletRepository;
        _userRepository = userRepository;
    }

    public async Task<Domain.Entities.Wallet?> GetByUserIdAsync(Guid userId)
    {
        //var user = await _userRepository.GetByIdAsync(userId);
        var wallet = await _walletRepository.GetByUserIdAsync(userId);
        return wallet;
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