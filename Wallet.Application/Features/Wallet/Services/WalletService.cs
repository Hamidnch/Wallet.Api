using MediatR;
using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Common.Enums;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<Domain.Entities.Wallet?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetByUserIdAsync(userId, cancellationToken);

        if (wallet != null)
            await _walletRepository.LoadCollectionAsync(wallet, w => w.Transactions, cancellationToken);

        return wallet;
    }

    public async Task<Unit> IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken)
    {
        await _walletRepository.IncreaseCashBalanceAsync(userId, amount, cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource, CancellationToken cancellationToken)
    {
        await _walletRepository.IncreaseNonCashBalanceAsync(userId, amount, nonCashSource, cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> DecreaseCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken)
    {
        await _walletRepository.DecreaseCashBalanceAsync(userId, amount, cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken)
    {
        await _walletRepository.IncreaseCashFromReturnAsync(userId, amount, cancellationToken);

        return Unit.Value;
    }
}