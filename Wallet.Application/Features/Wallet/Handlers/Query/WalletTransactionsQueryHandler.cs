﻿using MediatR;
using Wallet.Application.Features.Wallet.Dtos.Response;
using Wallet.Application.Features.Wallet.Queries;
using Wallet.Application.Features.Wallet.Services;

namespace Wallet.Application.Features.Wallet.Handlers.Query;

public class WalletTransactionsQueryHandler : IRequestHandler<GetWalletTransactionsQuery, IReadOnlyList<TransactionsWalletResponseDto>>
{
    private readonly IWalletService _walletService;

    public WalletTransactionsQueryHandler(IWalletService walletService)
    {
        _walletService = walletService;
    }

    public async Task<IReadOnlyList<TransactionsWalletResponseDto>> Handle(GetWalletTransactionsQuery query, CancellationToken cancellationToken)
    {
        var wallet = await _walletService.GetByUserIdAsync(query.RequestDto.UserId, cancellationToken);

        if (wallet is null)
            return new List<TransactionsWalletResponseDto>();

        var transactionDto =
            await _walletService.GetAllTransactionsByWalletId(CancellationToken.None,
                wallet.Id, query.RequestDto.From, query.RequestDto.To, query.RequestDto.Type);

        return transactionDto;
    }
}