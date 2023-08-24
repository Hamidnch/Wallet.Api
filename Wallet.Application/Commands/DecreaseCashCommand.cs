using MediatR;
using Wallet.Domain.Common;

namespace Wallet.Application.Commands;

public record DecreaseCashCommand(Guid WalletId, PositiveMoney Amount) : IRequest;