using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Command
{
    public sealed class UpdateProductCommand : IRequest<UpdateProductDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int ProductBranchId { get; set; }
        public string? ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal RegularPrice { get; set; }// Normal fiyat
        public decimal? SalePrice { get; set; }//Satış Fiyatı
        public string SKU { get; set; }//Stok Kodu
        public int Rating { get; set; }//Değerlendirme
        public int DiscountRate { get; set; }//Indirim oranı
        public int CategoryId { get; set; }


        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinnessRules _productBusinnessRules;

            public UpdateProductCommandHandler(IProductRepository productRepository,
                IMapper mapper, ProductBusinnessRules productBusinnessRules)
            => (_productRepository, _mapper, _productBusinnessRules) = (productRepository, mapper, productBusinnessRules);
            public async Task<UpdateProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                await _productBusinnessRules.ProductCanNotBeDuplicatedWhenInserted(request.Id);

                Product mappedProduct = _mapper.Map<Product>(request);
                Product updatedProduct = await _productRepository.UpdateAsync(mappedProduct);
                UpdateProductDto updateProductDto = _mapper.Map<UpdateProductDto>(updatedProduct);
                return updateProductDto;
            }
        }
    }
}
