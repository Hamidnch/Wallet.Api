using MediatR;
using Wallet.Domain.Common;

namespace Wallet.Application.Commands;

public record IncreaseCashFromReturnCommand(Guid WalletId, PositiveMoney Amount) : IRequest;