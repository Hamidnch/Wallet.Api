using MediatR;
using Wallet.Application.Features.Wallet.Dtos;
using Wallet.Application.Features.Wallet.Services;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Queries;

public class WalletTransactionsQueryHandler : IRequestHandler<GetWalletTransactionsQuery, IReadOnlyList<TransactionWalletDto>>
{
    private readonly IWalletService _walletService;

    public WalletTransactionsQueryHandler(IWalletService walletService)
    {
        _walletService = walletService;
    }

    public async Task<IReadOnlyList<TransactionWalletDto>> Handle(GetWalletTransactionsQuery query, CancellationToken cancellationToken)
    {
        var wallet = await _walletService.GetByUserIdAsync(query.UserId);

        if (wallet is null)
            return new List<TransactionWalletDto>();

        var transactionDto = wallet.Transactions
            .Select(p =>
                new TransactionWalletDto(p.Type, p.LastUpdated, new PositiveMoney(p.Amount), p.NonCashSource))
            .OrderBy(p => p.LastUpdated)
            .ThenBy(v => v.Type)
            .ToList();

        return transactionDto;
    }
}