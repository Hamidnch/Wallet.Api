using Wallet.Common.Enums;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Dtos;

public record TransactionsWalletResponseDto(TransactionType Type, DateTime CreatedOn, PositiveMoney Amount, NonCashSource NonCashSource);