using MediatR;
using Wallet.Application.Features.Wallet.Dtos.Response;
using Wallet.Common.Enums;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Services;

public interface IWalletService
{
    Task<Domain.Entities.Wallet?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);

    Task<IReadOnlyList<TransactionsWalletResponseDto>> GetAllTransactionsByWalletId(CancellationToken cancellationToken,
        Guid walletId, DateTime? from = null, DateTime? to = null, TransactionType transactionType = TransactionType.CashIncrease);

    Task<Unit> IncreaseCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken);
    Task<Unit> IncreaseNonCashBalanceAsync(Guid userId, PositiveMoney amount, NonCashSource nonCashSource, CancellationToken cancellationToken);
    Task<Unit> WithdrawCashBalanceAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken);
    Task<Unit> IncreaseCashFromReturnAsync(Guid userId, PositiveMoney amount, CancellationToken cancellationToken);
}