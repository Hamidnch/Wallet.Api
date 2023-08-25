using Microsoft.EntityFrameworkCore;
using Wallet.Domain.Entities;
using Wallet.Domain.ValueObjects;

namespace Wallet.Persistence.Context
{
    public class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Domain.Entities.Wallet>? Wallets { get; set; }
        public DbSet<TransactionWallet>? TransactionWallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}