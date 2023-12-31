﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wallet.Application.Features.Wallet.Dtos.Response;
using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Common.CommonHelpers;
using Wallet.Common.Enums;
using Wallet.Common.Extensions;
using Wallet.Domain.Common;
using Wallet.Domain.Entities;

namespace Wallet.Application.Features.Wallet.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;
    private readonly IMapper _mapper;

    public WalletService(IWalletRepository walletRepository, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
    }

    public async Task<Domain.Entities.Wallet?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetByUserIdAsync(userId, cancellationToken);

        if (wallet != null)
            await _walletRepository.LoadCollectionAsync(wallet, w => w.Transactions, cancellationToken);

        return wallet;
    }

    public async Task<IReadOnlyList<TransactionsWalletResponseDto>> GetAllTransactionsByWalletId(CancellationToken cancellationToken,
        Guid walletId, DateTime? from = null, DateTime? to = null, TransactionType transactionType = TransactionType.None)
    {
        var wallet = await _walletRepository.Table
            .FirstOrDefaultAsync(w => w.Id == walletId,
                cancellationToken: cancellationToken);

        if (wallet is null)
            return new List<TransactionsWalletResponseDto>();

        var transactions = wallet.Transactions as IEnumerable<TransactionWallet>;

        if (from.HasValue)
            transactions = transactions.Where(t => t.CreatedOn >= from.Value);

        if (to.HasValue)
            transactions = transactions.Where(t => t.CreatedOn <= to.Value);

        if (transactionType != TransactionType.None)
            transactions = transactions.Where(t => t.Type == transactionType);

        var transactionDtos =
            _mapper.Map<IEnumerable<TransactionWallet>, IEnumerable<TransactionsWalletResponseDto>>(transactions);

        return await transactionDtos
            .OrderBy(t => t.CreatedOn)
            .ThenBy(t => t.Type)
            .ToListAsync();
    }

    public async Task<Unit> IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken)
    {
        Assert.CheckValidGuid(userId);
        await _walletRepository.IncreaseCashBalanceAsync(userId, amount, cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource, CancellationToken cancellationToken)
    {
        Assert.CheckValidGuid(userId);
        await _walletRepository.IncreaseNonCashBalanceAsync(userId, amount, nonCashSource, cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> WithdrawCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken)
    {
        Assert.CheckValidGuid(userId);
        await _walletRepository.WithdrawCashBalanceAsync(userId, amount, cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken)
    {
        Assert.CheckValidGuid(userId);
        await _walletRepository.IncreaseCashFromReturnAsync(userId, amount, cancellationToken);

        return Unit.Value;
    }
}