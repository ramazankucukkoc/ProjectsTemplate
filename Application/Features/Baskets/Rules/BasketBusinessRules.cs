using Application.Features.Baskets.Constants;
using Application.Features.Brands.Constants;
using Application.Services.BrandService;
using Application.Services.ProductService;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;

namespace Application.Features.Baskets.Rules
{
    public class BasketBusinessRules
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;


        public BasketBusinessRules(IBasketRepository basketRepository, IProductService productService
            , IBrandService brandService)
        {
            _brandService = brandService;
            _basketRepository = basketRepository;
            _productService = productService;
        }

        public async Task BasketIdControl(int id)
        {
            Basket? result = await _basketRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException(BasketBusinessExceptionMessages.BasketIdExists);
        }
        public async Task BasketBrandIdControl(int brandId)
        {
            Basket? result = await _basketRepository.GetAsync(b => b.BrandId == brandId);
            if (result == null) throw new BusinessException(BasketBusinessExceptionMessages.BasketBrandIdExists);
        }
        public async Task BasketProductIdControl(int productId)
        {
            Basket? result = await _basketRepository.GetAsync(b => b.ProductId == productId);
            if (result == null) throw new BusinessException(BasketBusinessExceptionMessages.BasketProductExists);
        }
        public async Task BasketBrandIdActiveShoulExistsWhenInserted(bool active)
        {
            if (active == false) throw new BusinessException(BusinessRulesExceptionMessages.BrandNotExists);
        }
        public async Task ProductControl(int productId)
        {
            Product? product = await _productService.GetById(productId);
            if (product == null) throw new BusinessException(BasketBusinessExceptionMessages.BasketProductExists);

        }
        internal async Task BrandControl(int brandId)
        {
            Brand? brand = await _brandService.GetById(brandId);
            if (brand == null) throw new BusinessException(BasketBusinessExceptionMessages.BasketBrandExists);

        }
    }
}
