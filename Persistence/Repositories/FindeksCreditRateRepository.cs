using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class FindeksCreditRateRepository : EfRepositoryBase<FindeksCreditRate, ProjectDbContext>, IFindeksCreditRateRepository
    {
        public FindeksCreditRateRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
