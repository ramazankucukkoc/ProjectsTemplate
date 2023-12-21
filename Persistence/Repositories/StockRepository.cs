using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class StockRepository : EfRepositoryBase<Stock, ProjectDbContext>, IStockRepository
    {
        public StockRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
