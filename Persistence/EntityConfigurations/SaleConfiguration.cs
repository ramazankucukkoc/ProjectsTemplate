using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.Quantity).HasColumnName("Quantity").IsRequired();
            builder.Property(x => x.Price).HasColumnName("Price").IsRequired();
            builder.Property(x => x.TotalPrice).HasColumnName("TotalPrice").IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Product).WithMany(x => x.Sales).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Personel).WithMany(x => x.Sales).HasForeignKey(x => x.PersonelId);
            builder.HasOne(x => x.Customer).WithMany(x => x.Sales).HasForeignKey(x => x.CustomerId);


        }
    }
}
