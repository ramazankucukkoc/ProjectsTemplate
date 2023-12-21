using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
