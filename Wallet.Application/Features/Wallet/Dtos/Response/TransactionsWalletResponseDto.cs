using Wallet.Common.Enums;

namespace Wallet.Application.Features.Wallet.Dtos.Response;

public record TransactionsWalletResponseDto(TransactionType Type, DateTime CreatedOn, decimal Amount, NonCashSource NonCashSource);