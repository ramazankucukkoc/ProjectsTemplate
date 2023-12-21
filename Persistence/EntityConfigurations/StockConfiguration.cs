using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks");
            builder.Property(a => a.Id).HasColumnName("Id");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(a => a.Quantity).HasColumnName("Quantity").IsRequired();
            builder.HasOne(a => a.Product);
        }
    }
}
