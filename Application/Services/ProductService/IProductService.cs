using Domain.Entities;

namespace Application.Services.ProductService
{
    public interface IProductService
    {
        Task<Product> AddAsync(Product product);
        Task Add(Product product);
        Task<Product> GetByName(string name);
        Task<Product> GetById(int id);
        Task<decimal> GetUnitPriceById(int id);
        Task<byte[]> QrCodeToProductAsync(int productId);

    }
}
