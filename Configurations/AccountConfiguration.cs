using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ATMSystem.Models;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.AccountNumber);
        builder.Property(a => a.AccountNumber)
            .ValueGeneratedOnAdd();
        builder.Property(a => a.AccountType)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(a => a.Balance)
            .IsRequired()
            .HasColumnType("decimal(12,2)");
        builder.Property(a => a.CustomerId)
            .IsRequired();
        //builder.HasOne(a => a.Customer)
        //    .WithMany(c => c.Accounts)
        //    .HasForeignKey(a => a.CustomerId);
        builder.HasMany(a => a.Transactions)
            .WithOne(t => t.Account)
            .HasForeignKey(t => t.AccountNumber);
        builder.HasMany(a => a.Cards)
            .WithOne(c => c.Account)
            .HasForeignKey(c => c.AccountNumber);
    }
}
