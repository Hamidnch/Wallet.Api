using MediatR;
using Wallet.Domain.Common;

namespace Wallet.Application.Features.Wallet.Commands
{
    public record IncreaseCashCommand(Guid UserId, PositiveMoney Amount) : IRequest;
}