namespace Wallet.Application.Features.Wallet.Dtos.Request;

public record WithdrawCashDto(Guid UserId, decimal Amount);