using Wallet.Common.Enums;

namespace Wallet.Application.Features.Wallet.Dtos.Request;

public record IncreaseNonCashDto(Guid UserId, decimal Amount, NonCashSource NonCashSource);