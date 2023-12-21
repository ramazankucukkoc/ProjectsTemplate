using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("CustomerAddress");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(ca => ca.CustomerId).HasColumnName("CustomerId");
            builder.Property(ca => ca.AddressId).HasColumnName("AddressId");
            builder.HasIndex(ca => new { ca.CustomerId, ca.AddressId }, "UK_CustomerAddresss_CustomerId_AddressId").IsUnique();
            builder.HasOne(ca => ca.Address);
            builder.HasOne(ca => ca.Customer).WithMany().HasForeignKey(ca => ca.CustomerId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
