using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, ProjectDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
