using Wallet.Common.Enums;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Dtos;

public record TransactionWalletDto(TransactionType Type, DateTime LastUpdated, PositiveMoney Amount, NonCashSource NonCashSource);