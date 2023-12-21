using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class PersonelRepository : EfRepositoryBase<Personel, ProjectDbContext>, IPersonelRepository
    {
        public PersonelRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
