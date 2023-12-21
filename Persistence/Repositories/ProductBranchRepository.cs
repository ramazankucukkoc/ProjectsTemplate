using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProductBranchRepository : EfRepositoryBase<ProductBranch, ProjectDbContext>, IProductBranchRepository
    {
        public ProductBranchRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
