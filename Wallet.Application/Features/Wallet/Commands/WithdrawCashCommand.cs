using MediatR;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Commands;

public record WithdrawCashCommand(Guid UserId, PositiveMoney Amount) : IRequest;