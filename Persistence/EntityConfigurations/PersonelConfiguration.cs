using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class PersonelConfiguration : IEntityTypeConfiguration<Personel>
    {
        public void Configure(EntityTypeBuilder<Personel> builder)
        {
            builder.ToTable("Personels");
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(p => p.FirstName).IsRequired().HasColumnName("FirstName");
            builder.Property(p => p.LastName).IsRequired().HasColumnName("LastName");
            builder.Property(p => p.Gorsel).IsRequired().HasColumnName("Gorsel");
            builder.HasOne(p => p.Departman).WithMany(p => p.Personels).HasForeignKey(p => p.Departmanid);
        }
    }
}