using Microsoft.EntityFrameworkCore;
using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Persistence.Context;

namespace Wallet.Persistence.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly WalletDbContext _dbContext;

        public WalletRepository(WalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Entities.Wallet> GetByIdAsync(Guid id)
        {
            if (_dbContext.Users is null)
                throw new Exception("Users table not found");

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Wallet.Id == id)
                       ?? throw new Exception("user is null");
            return user.Wallet;

        }

        public async Task<Domain.Entities.Wallet> GetByUserIdAsync(Guid userId)
        {
            if (_dbContext.Users is null)
                throw new Exception("Users table not found");

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId)
                       ?? throw new Exception("user is null");
            return user.Wallet;
        }

        public Task AddAsync(Domain.Entities.Wallet wallet)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Entities.Wallet wallet)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}