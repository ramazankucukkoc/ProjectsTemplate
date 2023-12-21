using Application.Features.Invoices.Dtos;
using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IInvoiceRepository : IAsyncRepository<Invoice>
    {
        Task<CreateInvoiceDto?> GetInvoiceDetailsById(int Id);
    }
}
