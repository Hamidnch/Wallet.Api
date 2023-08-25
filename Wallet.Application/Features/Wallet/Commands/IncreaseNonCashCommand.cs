using MediatR;
using Wallet.Domain.Common;
using Wallet.Domain.Enums;

namespace Wallet.Application.Features.Wallet.Commands;

public record IncreaseNonCashCommand(Guid UserId, PositiveMoney Amount, NonCashSource NonCashSource) : IRequest;