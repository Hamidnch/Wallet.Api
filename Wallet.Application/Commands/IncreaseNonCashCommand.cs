using MediatR;
using Wallet.Domain.Common;
using Wallet.Domain.Enums;

namespace Wallet.Application.Commands;

public record IncreaseNonCashCommand(Guid WalletId, PositiveMoney Amount, NonCashSource NonCashSource) : IRequest;