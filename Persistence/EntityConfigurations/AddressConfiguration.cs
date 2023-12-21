using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.Property(a => a.Id).HasColumnName("Id");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(a => a.CityId).HasColumnName("CityId").IsRequired();
            builder.Property(a => a.AddressDetail).HasColumnName("AddressDetail").IsRequired().HasMaxLength(150);
            builder.Property(a => a.AddressAbbreviation).HasColumnName("AddressAbbreviation").IsRequired().HasMaxLength(150);
            builder.Property(a => a.PostalCode).HasColumnName("PostalCode").IsRequired().HasMaxLength(50);
            builder.HasOne(a => a.User);
            builder.HasOne(a => a.Country)
                .WithMany() // Ülkelerin birçok adresi olabilir ama zorunlu değilse WithMany() kullanılabilir.
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.NoAction); 
            builder.HasOne(a => a.City).WithMany(a => a.Address).HasForeignKey(a => a.CityId);
            builder.HasMany(a => a.CustomerAddress);
           
        }
    }
}
