using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ATMSystem.Models;

public class ATMConfiguration : IEntityTypeConfiguration<ATM>
{
    public void Configure(EntityTypeBuilder<ATM> builder)
    {
        builder.HasKey(a => a.AtmId);
        builder.Property(a => a.AtmId)
            .ValueGeneratedOnAdd();
        builder.Property(a => a.Location).IsRequired().HasMaxLength(100);
        builder.Property(a => a.CashAvailable).IsRequired().HasColumnType("decimal(12,2)");
        builder.Property(a => a.Status).IsRequired().HasMaxLength(20);
        builder.HasMany(a => a.Transactions).WithOne(t => t.ATM).HasForeignKey(t => t.AtmId);
    }
}
