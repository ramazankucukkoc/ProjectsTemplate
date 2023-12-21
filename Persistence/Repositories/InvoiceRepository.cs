using Application.Features.Invoices.Dtos;
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class InvoiceRepository : EfRepositoryBase<Invoice, ProjectDbContext>, IInvoiceRepository
    {
        public InvoiceRepository(ProjectDbContext context) : base(context)
        {
        }

        public async Task<CreateInvoiceDto?> GetInvoiceDetailsById(int Id)
        {
            var result = from i in Context.Invoices
                         join p in Context.Products
                         on i.ProductId equals p.Id
                         join s in Context.Stocks
                         on p.Id equals s.ProductId
                         join cu in Context.Customers
                         on i.CustomerId equals cu.Id
                         join u in Context.Users
                         on cu.UserId equals u.Id
                         join b in Context.Brands
                         on p.BrandId equals b.Id
                         join ca in Context.Categories
                         on p.CategoryId equals ca.Id
                         where i.Id == Id
                         select new CreateInvoiceDto
                         {
                             BrandName = b.Name,
                             CategoryName = ca.Name,
                             CustomerEmail = u.Email,
                             CustomerName = u.FirstName + " " + u.LastName,
                             ProductName = p.Name,
                             No = i.No,
                             TotalSum = Convert.ToDouble(s.Quantity * p.SalePrice)
                         };
            return await result.FirstOrDefaultAsync();

        }
    }
}
