using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Dtos;

public record WalletResponseDto(Guid UserId, PositiveMoney CashBalance, PositiveMoney NonCashBalance);