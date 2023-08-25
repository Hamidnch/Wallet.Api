using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Domain.ValueObjects;

namespace Wallet.Persistence.Configs;

public class TransactionWalletConfig : IEntityTypeConfiguration<TransactionWallet>
{
    public void Configure(EntityTypeBuilder<TransactionWallet> builder)
    {
        builder.ToTable("TransactionsWallet");
        builder.Property(w => w.Amount).HasConversion(new PositiveMoneyConverter());
    }
}