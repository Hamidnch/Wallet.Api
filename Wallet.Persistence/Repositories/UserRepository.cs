using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Domain.Entities;
using Wallet.Persistence.Context;

namespace Wallet.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(WalletDbContext context) : base(context)
    {
    }

    public async Task<Domain.Entities.Wallet?> GetWalletByUserIdAsync(Guid userId)
    {
        var user = await DbSet.FindAsync(userId);
        return null;
    }
}