using Application.Features.Sales.Dtos;
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SaleRepository : EfRepositoryBase<Sale, ProjectDbContext>, ISaleRepository
    {
        public SaleRepository(ProjectDbContext context) : base(context)
        {
        }

        public async Task<CreateSaleDto?> GetById(int id)
        {
            var result = from s in Context.Sales
                         join p in Context.Products
                         on s.ProductId equals p.Id
                         join b in Context.Brands
                         on p.BrandId equals b.Id
                         join ca in Context.Categories
                         on p.CategoryId equals ca.Id
                         join pb in Context.ProductBranches
                         on p.ProductBranchId equals pb.Id
                         join c in Context.Customers
                         on s.CustomerId equals c.Id
                         join u in Context.Users
                         on c.Id equals u.Id
                         join pe in Context.Personels
                         on s.PersonelId equals pe.Id
                         where u.Id == id
                         select new CreateSaleDto
                         {
                             BrandName = b.Name,
                             CategroyName = ca.Name,
                             CustomerName = u.FirstName + " " + u.LastName,
                             PersonelName = pe.FirstName + " " + pe.LastName,
                             TotalPrice = p.RegularPrice * s.Quantity,
                             ProductBranchName = pb.Name,
                             ProductName = p.Name,
                             Quantity = s.Quantity,
                         };
            return await result.FirstOrDefaultAsync();

        }
    }
}
