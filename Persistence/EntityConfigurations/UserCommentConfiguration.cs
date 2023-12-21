using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserCommentConfiguration : IEntityTypeConfiguration<UserComment>
    {
        public void Configure(EntityTypeBuilder<UserComment> builder)
        {
            builder.ToTable("UserComments");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.Comment).HasColumnName("Comment").IsRequired();
            builder.Property(x => x.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            builder.HasOne(x => x.User);
            builder.HasOne(x => x.Product).WithMany(x => x.UserComments).HasForeignKey(x => x.ProductId);
        }
    }
}
