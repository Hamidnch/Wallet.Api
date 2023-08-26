using MediatR;
using Wallet.Common.Enums;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Commands;

public record IncreaseNonCashCommand(Guid UserId, PositiveMoney Amount, NonCashSource NonCashSource) : IRequest;