using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Dtos;

public record WalletDto(Guid UserId, PositiveMoney CashBalance, PositiveMoney NonCashBalance;