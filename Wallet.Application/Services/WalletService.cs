using Wallet.Application.Contracts;
using Wallet.Domain.Common;
using Wallet.Domain.Enums;

namespace Wallet.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task IncreaseCashBalanceAsync(Guid walletId, PositiveMoney amount)
        {
            var wallet = await _walletRepository.GetByIdAsync(walletId);
            wallet.IncreaseCash(amount);
            await _walletRepository.UpdateAsync(wallet);
        }

        public async Task IncreaseNonCashBalanceAsync(Guid walletId, PositiveMoney amount, NonCashSource nonCashSource)
        {
            var wallet = await _walletRepository.GetByIdAsync(walletId);
            wallet.IncreaseNonCash(amount, nonCashSource);
            await _walletRepository.UpdateAsync(wallet);
        }

        public async Task DecreaseCashBalanceAsync(Guid walletId, PositiveMoney amount)
        {
            var wallet = await _walletRepository.GetByIdAsync(walletId);
            wallet.DecreaseCash(amount);
            await _walletRepository.UpdateAsync(wallet);
        }

        public async Task IncreaseCashFromReturnAsync(Guid walletId, PositiveMoney amount)
        {
            var wallet = await _walletRepository.GetByIdAsync(walletId);
            wallet.IncreaseCashFromReturn(amount);
            await _walletRepository.UpdateAsync(wallet);
        }
    }
}