using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CorporateCustomerRepository : EfRepositoryBase<CorporateCustomer, ProjectDbContext>, ICorporateCustomerRepository
    {
        public CorporateCustomerRepository(ProjectDbContext context) : base(context)
        {
        }
    }

}
