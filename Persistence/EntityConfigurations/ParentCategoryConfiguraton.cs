using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class ParentCategoryConfiguraton : IEntityTypeConfiguration<ParentCategory>
    {
        public void Configure(EntityTypeBuilder<ParentCategory> builder)
        {
            builder.ToTable("ParentCategories");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        }
    }
}
