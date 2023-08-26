using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Wallet.Common.CommonHelpers;
using Wallet.Domain.Entities;
using Wallet.Persistence.Extensions;

namespace Wallet.Persistence.Context
{
    public class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Domain.Entities.Wallet>? Wallets { get; set; }
        public DbSet<TransactionWallet>? TransactionWallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(DefaultConstants.DefaultSchema);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.SetDecimalPrecision();
            modelBuilder.AddDateTimeOffsetConverter();
            modelBuilder.AddDateTimeUtcKindConverter();
            modelBuilder.AddDecimalConverter();
        }
    }
}