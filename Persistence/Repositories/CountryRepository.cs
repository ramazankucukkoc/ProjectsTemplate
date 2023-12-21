using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CountryRepository : EfRepositoryBase<Country, ProjectDbContext>, ICountryRepository
    {
        public CountryRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
