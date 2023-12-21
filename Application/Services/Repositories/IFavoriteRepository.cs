using Application.Features.Favorites.Dtos;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IFavoriteRepository : IAsyncRepository<Favorite>
    {
        Task<IPaginate<GetByIdFavoriteDto>> GetAllFavoriteAsync(int productId,int index=0,int size= 10,CancellationToken cancellationToken=default);

    }
}
