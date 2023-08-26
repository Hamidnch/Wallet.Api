using Wallet.Domain.Entities;

namespace Wallet.Application.Features.Wallet.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<Domain.Entities.Wallet?> GetWalletByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}