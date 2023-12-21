using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, ProjectDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
