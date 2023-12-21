using Application.Features.Baskets.Dtos;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IBasketRepository : IAsyncRepository<Basket>
    {
        Task<IPaginate<BasketListDto>> GetAllBaskets(int index = 0, int size = 10, CancellationToken cancellationToken = default);
        Task<IPaginate<Basket>> GetAllBaskets2(int index = 0, int size = 10, CancellationToken cancellationToken = default);
        Task<IPaginate<BasketListDto>> GetAllProductBaskets(int productId, int index = 0, int size = 10, CancellationToken cancellationToken = default);

    }
}
