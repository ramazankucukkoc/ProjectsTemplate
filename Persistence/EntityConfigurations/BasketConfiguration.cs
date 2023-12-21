using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Baskets");
            builder.Property(b => b.Id).HasColumnName("Id");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseIdentityColumn();
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.ProductId).IsRequired().HasColumnName("ProductId");
            builder.Property(b => b.BrandId).IsRequired().HasColumnName("BrandId");
            builder.Property(b => b.UserId).IsRequired().HasColumnName("UserId");
            builder.Property(b => b.Count).IsRequired().HasColumnName("Count");
            //builder.Property(b => b.TotalPrice).IsRequired().HasColumnName("TotalPrice").HasColumnType("decimal(18,2)");
            builder.HasOne(b => b.User);
            builder.HasOne(b => b.Product).WithMany(b => b.Baskets).HasForeignKey(b => b.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(b => b.Brand).WithMany(b => b.Baskets).HasForeignKey(b => b.BrandId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}