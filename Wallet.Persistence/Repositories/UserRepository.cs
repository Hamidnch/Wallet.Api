using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Domain.Entities;
using Wallet.Persistence.Context;

namespace Wallet.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(WalletDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Domain.Entities.Wallet?> GetWalletByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await Entities.FindAsync(userId);
        return null;
    }
}