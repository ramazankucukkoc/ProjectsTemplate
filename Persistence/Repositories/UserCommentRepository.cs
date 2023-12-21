using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserCommentRepository : EfRepositoryBase<UserComment, ProjectDbContext>, IUserCommentRepository
    {
        public UserCommentRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
