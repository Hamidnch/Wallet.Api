using Wallet.Domain.Common;
using Wallet.Domain.Enums;

namespace Wallet.Application.Features.Wallet.Dtos;

public record TransactionWalletDto(TransactionType Type, DateTime LastUpdated, PositiveMoney Amount, NonCashSource NonCashSource);