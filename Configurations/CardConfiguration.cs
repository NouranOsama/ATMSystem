using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ATMSystem.Models;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(c => c.CardId);
        builder.Property(c => c.CardId).ValueGeneratedOnAdd();
        builder.Property(c => c.CardNumber).IsRequired().HasMaxLength(16);
        builder.Property(c => c.PinHash).IsRequired().HasMaxLength(100);
        builder.Property(c => c.ExpiryDate).IsRequired();
        builder.Property(c => c.AccountNumber).IsRequired();
        builder.HasOne(c => c.Account).WithMany(a => a.Cards).HasForeignKey(c => c.AccountNumber);
    }

}
