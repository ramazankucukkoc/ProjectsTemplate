using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ParentCategoryRepository : EfRepositoryBase<ParentCategory, ProjectDbContext>, IParentCategoryRepository
    {
        public ParentCategoryRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
