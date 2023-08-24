namespace Wallet.Application.Contracts;

public interface IWalletRepository
{
    Task<Domain.Entities.Wallet> GetByIdAsync(Guid id);
    Task AddAsync(Domain.Entities.Wallet wallet);
    Task UpdateAsync(Domain.Entities.Wallet wallet);
}