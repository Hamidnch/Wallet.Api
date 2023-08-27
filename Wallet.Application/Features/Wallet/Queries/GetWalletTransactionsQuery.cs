using MediatR;
using Wallet.Application.Features.Wallet.Dtos.Request;
using Wallet.Application.Features.Wallet.Dtos.Response;

namespace Wallet.Application.Features.Wallet.Queries;

public record GetWalletTransactionsQuery(TransactionsWalletRequestDto RequestDto) : IRequest<IReadOnlyList<TransactionsWalletResponseDto>>;