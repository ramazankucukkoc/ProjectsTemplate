using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CategoryRepository : EfRepositoryBase<Category, ProjectDbContext>, ICategoryRepository
    {
        public CategoryRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
