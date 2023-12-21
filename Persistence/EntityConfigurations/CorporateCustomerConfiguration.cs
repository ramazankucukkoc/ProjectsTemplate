using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
    {
        public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
        {
            builder.ToTable("CorporateCustomers");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(c => c.CustomerId).HasColumnName("CustomerId");
            builder.HasIndex(c => c.CustomerId, "UK_CorporateCustomers_CustomerId").IsUnique();
            builder.Property(c => c.CompanyName).HasColumnName("CompanyName");
            builder.Property(c => c.TaxNo).HasColumnName("TaxNo");
            builder.HasIndex(c => c.TaxNo, "UK_CorporateCustomers_TaxNo").IsUnique();
            builder.HasOne(c => c.Customer);
        }
    }
}
