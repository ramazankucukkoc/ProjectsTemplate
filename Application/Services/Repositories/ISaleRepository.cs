using Application.Features.Sales.Dtos;
using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface ISaleRepository : IAsyncRepository<Sale>
    {
        Task<CreateSaleDto?> GetById(int id);
    }
}
