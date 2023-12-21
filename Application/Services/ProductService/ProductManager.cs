using Application.Services.QRCodeService;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;
using System.Text.Json;

namespace Application.Services.ProductService
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IQRCodeService _qRCodeService;
        public ProductManager(IProductRepository productRepository, IQRCodeService qRCodeService)
        {
            _qRCodeService = qRCodeService;
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task<Product> AddAsync(Product product)
        {
            Product? createdProduct = await _productRepository.AddAsync(product);
            return createdProduct;
        }

        public async Task<Product> GetById(int id)
        {
            Product? product = await _productRepository.GetAsync(p => p.Id == id);
            return product;

        }

        public async Task<Product> GetByName(string name)
        {
            Product? product = await _productRepository.GetAsync(p => p.Name.ToLower().Trim() == name.ToLower().Trim());
            return product;
        }

        public async Task<decimal> GetUnitPriceById(int id)
        {
            Product? result = await _productRepository.GetAsync(p => p.Id == id);
            if (result is null) throw new BusinessException("Ürün bulunamadı");

            return result.RegularPrice;
        }

        public async Task<byte[]> QrCodeToProductAsync(int productId)
        {
            Product? product = await _productRepository.GetAsync(p => p.Id == productId);

            var plainObject = new
            {
                product.Id,
                product.Name,
                product.RegularPrice,
                product.SalePrice,
                product.CreatedDate
            };
            //plainText:düz metin
            string plainText = JsonSerializer.Serialize(plainObject);
            return _qRCodeService.GenerateQRCode(plainText);
        }
    }
}
