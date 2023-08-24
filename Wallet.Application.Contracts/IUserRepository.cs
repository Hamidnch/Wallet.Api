using Wallet.Domain.Entities;

namespace Wallet.Application.Contracts;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);
    Task<User> GetByWalletIdAsync(Guid walletId);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
}