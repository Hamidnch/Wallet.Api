using MediatR;
using Wallet.Application.Contracts;
using Wallet.Domain.Entities;

namespace Wallet.Application.Queries.Handlers
{
    public class UserQueryHandler : IRequestHandler<GetWalletTransactionsQuery, IReadOnlyList<TransactionWallet>>
    {
        private readonly IWalletRepository _walletRepository;

        public UserQueryHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<IReadOnlyList<TransactionWallet>> Handle(GetWalletTransactionsQuery query, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetByIdAsync(query.WalletId);
            return wallet.Transactions;
        }
    }
}