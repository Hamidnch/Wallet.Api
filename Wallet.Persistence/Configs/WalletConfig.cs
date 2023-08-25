using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wallet.Persistence.Configs;

public class WalletConfig : IEntityTypeConfiguration<Domain.Entities.Wallet>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Wallet> builder)
    {
        builder.ToTable("Wallets");
        builder.HasKey(x => x.Id);
        builder.Property(w => w.CashBalance);
        builder.Property(w => w.NonCashBalance);
        builder.Property(w => w.CashBalance).HasConversion(new PositiveMoneyConverter());
        builder.Property(w => w.NonCashBalance).HasConversion(new PositiveMoneyConverter());

        builder
            .HasMany(w => w.Transactions)
            .WithOne()
            .HasForeignKey("WalletId")
            .OnDelete(DeleteBehavior.NoAction);
    }
}