using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ATMSystem.Models;

public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
{
    public void Configure(EntityTypeBuilder<TransactionType> builder)
    {
        builder.HasKey(tt => tt.TransactionTypeId);
        builder.Property(tt => tt.TypeName).IsRequired().HasMaxLength(50);
        builder.HasMany(tt => tt.Transactions).WithOne(t => t.TransactionType).HasForeignKey(t => t.TransactionTypeId);
    }
}
