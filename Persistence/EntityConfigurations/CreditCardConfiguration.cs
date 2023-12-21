using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCart>
    {
        public void Configure(EntityTypeBuilder<CreditCart> builder)
        {
            builder.ToTable("CreditCarts");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.NameOnTheCard).HasColumnName("NameOnTheCard").IsRequired();
            builder.Property(x => x.CardNumber).HasColumnName("CardNumber").IsRequired();
            builder.Property(c => c.CardCvv).HasColumnName("CardCvv").IsRequired();
            builder.Property(c => c.ExpirationDate).HasColumnName("ExpirationDate").IsRequired();
            builder.Property(c => c.MoneyInTheCard).HasColumnName("MoneyInTheCard").IsRequired();
            builder.HasOne(x => x.User);
        }
    }
}
