using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.SubTotal).HasColumnName("SubTotal").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DisCount).HasColumnName("DisCount").IsRequired();
            builder.Property(x => x.Tax).HasColumnName("Tax").IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(x => x.Phone).HasColumnName("Phone").IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").IsRequired();
            builder.Property(x => x.IsShippingDifferent).HasColumnName("IsShippingDifferent").HasDefaultValue(false);
            builder.Property(x => x.CanceledDate).HasColumnName("CanceledDate").IsRequired();
            builder.Property(x => x.DeliveredDate).HasColumnName("DeliveredDate").IsRequired();
            builder.HasOne(x => x.Address).WithMany(x => x.Orders).HasForeignKey(x => x.AddressId);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(deleteBehavior: DeleteBehavior.NoAction);
        }
    }
}
