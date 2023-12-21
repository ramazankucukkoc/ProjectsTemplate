using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CustomerRepository : EfRepositoryBase<Customer, ProjectDbContext>, ICustomerRepository
    {
        public CustomerRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
