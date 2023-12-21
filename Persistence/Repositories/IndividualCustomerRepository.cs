using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class IndividualCustomerRepository : EfRepositoryBase<IndividualCustomer, ProjectDbContext>, IIndividualCustomerRepository
    {
        public IndividualCustomerRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
