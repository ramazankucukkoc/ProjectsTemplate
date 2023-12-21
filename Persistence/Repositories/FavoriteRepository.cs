using Application.Features.Favorites.Dtos;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class FavoriteRepository : EfRepositoryBase<Favorite, ProjectDbContext>, IFavoriteRepository
    {
        public FavoriteRepository(ProjectDbContext context) : base(context)
        {
        }

        public async Task<IPaginate<GetByIdFavoriteDto>> GetAllFavoriteAsync(int productId, int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            IQueryable<GetByIdFavoriteDto> result = from f in Context.Favorites
                                                    join u in Context.Users
                                                    on f.UserId equals u.Id
                                                    join b in Context.Brands
                                                    on f.BrandId equals b.Id
                                                    join p in Context.Products
                                                    on f.ProductId equals p.Id
                                                    where f.ProductId == productId
                                                    select new GetByIdFavoriteDto
                                                    {
                                                        BrandId = b.Id,
                                                        BrandName = b.Name,
                                                        Id = f.Id,
                                                        ProductId = p.Id,
                                                        ProductName = p.Name,
                                                        UserEmail = u.Email,
                                                        UserId = u.Id,
                                                        UserName = u.FirstName + " " + u.LastName
                                                    };
            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }
    }
}
