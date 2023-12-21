using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, ProjectDbContext>, IOtpAuthenticatorRepository
    {
        public OtpAuthenticatorRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
