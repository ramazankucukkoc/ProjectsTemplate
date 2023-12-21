using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BrandRepository : EfRepositoryBase<Brand, ProjectDbContext>, IBrandRepository
    {
        public BrandRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
