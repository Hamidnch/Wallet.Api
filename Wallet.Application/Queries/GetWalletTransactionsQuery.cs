using MediatR;
using Wallet.Domain.Entities;

namespace Wallet.Application.Queries;

public record GetWalletTransactionsQuery(Guid WalletId) : IRequest<IReadOnlyList<TransactionWallet>>;