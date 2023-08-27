using MediatR;
using Wallet.Application.Features.Wallet.Dtos;
using Wallet.Common.Enums;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Services;

public interface IWalletService
{
    Task<Domain.Entities.Wallet?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);

    Task<IReadOnlyList<TransactionsWalletResponseDto>> GetAllTransactionsByWalletId(CancellationToken cancellationToken,
        Guid walletId, DateTime? date = null, TransactionType transactionType = TransactionType.CashIncrease);

    Task<Unit> IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken);
    Task<Unit> IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource, CancellationToken cancellationToken);
    Task<Unit> DecreaseCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken);
    Task<Unit> IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken);
}