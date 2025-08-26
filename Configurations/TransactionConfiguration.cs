    using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ATMSystem.Models;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.TransactionId);
        builder.Property(t => t.Amount).IsRequired().HasColumnType("decimal(12,2)");
        builder.Property(t => t.TransactionDateTime).IsRequired();
        builder.Property(t => t.Status).IsRequired().HasMaxLength(20);
        builder.Property(t => t.Status)
       .HasDefaultValue("Success");   
        builder.Property(t => t.TransactionTypeId).IsRequired();
        builder.Property(t => t.AccountNumber).IsRequired();
        builder.HasOne(t => t.TransactionType).WithMany().HasForeignKey(t => t.TransactionTypeId);
        builder.HasOne(t => t.Account).WithMany(a => a.Transactions).HasForeignKey(t => t.AccountNumber);
        builder.HasOne(t => t.ATM).WithMany(a => a.Transactions).HasForeignKey(t => t.AtmId).IsRequired(false);
    }
}
