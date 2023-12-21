using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime2");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("datetime2");
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
        }
    }
}
