using MediatR;
using Wallet.Application.Features.Wallet.Dtos;

namespace Wallet.Application.Features.Wallet.Queries;

public record GetWalletTransactionsQuery(Guid UserId) : IRequest<IReadOnlyList<TransactionWalletDto>>;