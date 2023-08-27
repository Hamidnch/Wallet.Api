using Wallet.Common.Enums;

namespace Wallet.Application.Features.Wallet.Dtos;

public record TransactionsWalletRequestDto(Guid UserId, TransactionType Type, DateTime? From, DateTime? To);