using MediatR;
using Microsoft.EntityFrameworkCore;
using Wallet.Application.Features.Wallet.Dtos;
using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Common.Enums;
using Wallet.Common.Extensions;
using Wallet.Domain.Common;
using Wallet.Domain.Entities;

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

    public async Task<IReadOnlyList<TransactionsWalletResponseDto>> GetAllTransactionsByWalletId(CancellationToken cancellationToken,
        Guid walletId, DateTime? date = null, TransactionType transactionType = TransactionType.None)
    {
        var wallet = await _walletRepository.Table
            .FirstOrDefaultAsync(w => w.Id == walletId,
                cancellationToken: cancellationToken);

        if (wallet is null)
            return new List<TransactionsWalletResponseDto>();

        var transactions = wallet.Transactions as IEnumerable<TransactionWallet>;

        if (date != null && date != DateTime.MinValue /*&& date.ToString() != "{1/1/0001 12:00:00 AM}"*/)
            transactions = transactions.Where(t => t.LastUpdated == date.Value);

        if (transactionType != TransactionType.None)
            transactions = transactions.Where(t => t.Type == transactionType);

        var transactionDto = transactions.Select(p =>
                new TransactionsWalletResponseDto(p.Type, p.LastUpdated,
                    new PositiveMoney(p.Amount), p.NonCashSource))
            .OrderBy(t => t.LastUpdated)
            .ThenBy(t => t.Type); ;

        return await transactionDto.ToListAsync();
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