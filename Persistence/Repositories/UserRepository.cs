using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, ProjectDbContext>, IUserRepository
    {
        public UserRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
