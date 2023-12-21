using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CreditCartRepository : EfRepositoryBase<CreditCart, ProjectDbContext>, ICreditCartRepository
    {
        public CreditCartRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
