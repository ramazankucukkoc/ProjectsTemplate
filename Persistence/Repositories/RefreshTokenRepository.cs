using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, ProjectDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
