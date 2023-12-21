using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices").HasKey(i => i.Id);
            builder.Property(i => i.Id).HasColumnName("Id").UseIdentityColumn();
            builder.Property(i => i.CustomerId).HasColumnName("CustomerId");
            builder.Property(i => i.No).HasColumnName("No");
            builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").HasDefaultValue(DateTime.Now);
            builder.HasOne(i => i.Customer).WithMany(i => i.Invoices).HasForeignKey(i => i.CustomerId);
        }
    }
}