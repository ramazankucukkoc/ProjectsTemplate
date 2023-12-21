using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class ProductBranchConfiguration : IEntityTypeConfiguration<ProductBranch>
    {
        public void Configure(EntityTypeBuilder<ProductBranch> builder)
        {
            builder.ToTable("ProductBranches").HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("Id");
            builder.Property(r => r.Cities).HasColumnName("Cities");
        }
    }
}
