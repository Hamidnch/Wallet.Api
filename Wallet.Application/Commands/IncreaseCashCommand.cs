using MediatR;
using Wallet.Domain.Common;

namespace Wallet.Application.Commands
{
    public record IncreaseCashCommand(Guid WalletId, PositiveMoney Amount) : IRequest;
}