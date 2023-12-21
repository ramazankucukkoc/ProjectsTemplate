using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Seeds
{
    public class OperationClaimSeed : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            OperationClaim[] operationClaims = { new(1, "Admin") };
            builder.HasData(operationClaims);
        }
    }
}
