using MediatR;
using Wallet.Application.Features.Wallet.Dtos;
using Wallet.Application.Features.Wallet.Services;

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
        var transactionDto = wallet.Transactions
            .Select(p =>
                new TransactionWalletDto(p.Type, p.LastUpdated, p.Amount, p.NonCashSource))
            .OrderBy(p => p.LastUpdated)
            .ThenBy(v => v.Type)
            .ToList();

        return transactionDto;
    }
}