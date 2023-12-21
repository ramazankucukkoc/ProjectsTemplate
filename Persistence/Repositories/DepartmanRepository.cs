using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class DepartmanRepository : EfRepositoryBase<Departman, ProjectDbContext>, IDepartmanRepository
    {
        public DepartmanRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
