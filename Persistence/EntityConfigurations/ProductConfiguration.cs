using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(250);
            builder.Property(x => x.ShortDescription).HasColumnName("ShortDescription").HasMaxLength(100);
            builder.Property(x => x.RegularPrice).HasColumnName("RegularPrice");
            builder.Property(x => x.SalePrice).HasColumnName("SalePrice");
            builder.Property(x => x.SKU).HasColumnName("SKU");
            builder.Property(x => x.Rating).HasColumnName("Rating");
            builder.Property(x => x.DiscountRate).HasColumnName("DiscountRate");
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId);
            builder.HasOne(x => x.ProductBranch).WithMany(x => x.Products).HasForeignKey(x => x.ProductBranchId);
            builder.HasOne(x => x.Stock);

        }
    }
}
