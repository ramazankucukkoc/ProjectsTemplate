using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CityRepository : EfRepositoryBase<City, ProjectDbContext>, ICityRepository
    {
        public CityRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
