using MediatR;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Commands;

public record DecreaseCashCommand(Guid UserId, PositiveMoney Amount) : IRequest;