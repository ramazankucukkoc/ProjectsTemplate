using Application.Features.Baskets.Dtos;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BasketRepository : EfRepositoryBase<Basket, ProjectDbContext>, IBasketRepository
    {
        public BasketRepository(ProjectDbContext context) : base(context)
        {
        }

        public async Task<IPaginate<BasketListDto>> GetAllBaskets(int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            IQueryable<BasketListDto> result = from b in Context.Baskets
                                               join p in Context.Products
                                               on b.ProductId equals p.Id
                                               join u in Context.Users
                                               on b.UserId equals u.Id
                                               join brand in Context.Brands
                                               on b.BrandId equals brand.Id
                                               select new BasketListDto
                                               {
                                                   Id = b.Id,
                                                   BrandName = brand.Name,
                                                   Count = b.Count,
                                                   ProductId = b.ProductId,
                                                   ProductName = p.Name,
                                                   UserEmail = u.Email,
                                                   ProductUnitPrice = p.RegularPrice,
                                                   UserName = u.FirstName + " " + u.LastName
                                               };
            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task<IPaginate<Basket>> GetAllBaskets2(int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = Context.Baskets
                 .Include(b => b.Product)
                 .Include(b => b.User)
                 .Include(b => b.Brand)
                 .ToPaginateAsync(index, size, 0, cancellationToken);
            return await result;
        }

        public async Task<IPaginate<BasketListDto>> GetAllProductBaskets(int productId, int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            IQueryable<BasketListDto> result = from b in Context.Baskets
                                               join p in Context.Products
                                               on b.ProductId equals p.Id
                                               join u in Context.Users
                                               on b.UserId equals u.Id
                                               join brand in Context.Brands
                                               on b.BrandId equals brand.Id
                                               where b.ProductId == productId
                                               select new BasketListDto
                                               {
                                                   Id = b.Id,
                                                   BrandName = brand.Name,
                                                   Count = b.Count,
                                                   ProductId = b.ProductId,
                                                   ProductName = p.Name,
                                                   UserEmail = u.Email,
                                                   ProductUnitPrice = p.RegularPrice,
                                                   UserName = u.FirstName + " " + u.LastName
                                               };
            return await result.ToPaginateAsync(index, size, 0, cancellationToken);

        }
    }
}
