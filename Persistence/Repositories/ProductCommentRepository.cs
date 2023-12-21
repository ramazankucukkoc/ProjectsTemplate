using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProductCommentRepository : EfRepositoryBase<ProductComment, ProjectDbContext>, IProductCommentRepository
    {
        public ProductCommentRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
