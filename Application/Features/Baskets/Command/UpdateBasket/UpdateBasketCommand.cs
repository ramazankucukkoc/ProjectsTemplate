using Application.Features.Baskets.Dtos;
using Application.Features.Baskets.Rules;
using Application.Services.BrandService;
using Application.Services.ProductService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Baskets.Command.UpdateBasket
{
    public class UpdateBasketCommand : IRequest<UpdateBasketDto>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int Count { get; set; }
        public int UserId { get; set; }

        public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, UpdateBasketDto>
        {
            private readonly IBasketRepository _basketRepository;
            private readonly IMapper _mapper;
            private readonly BasketBusinessRules _basketBusinessRules;
            private readonly IProductService _productService;
            private readonly IBrandService _brandService;

            public UpdateBasketCommandHandler(IBasketRepository basketRepository,
                IMapper mapper, BasketBusinessRules basketBusinessRules, IProductService productService, IBrandService brandService)
            =>
                (_basketRepository, _mapper, _basketBusinessRules, _productService, _brandService)
                = (basketRepository, mapper, basketBusinessRules, productService, brandService);
            public async Task<UpdateBasketDto> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
            {
                await _basketBusinessRules.ProductControl(request.ProductId);
                await _basketBusinessRules.BrandControl(request.BrandId);
                await _basketBusinessRules.BasketIdControl(request.Id);
                Basket? basket = await _basketRepository.GetAsync(b => b.Id == request.Id);
                basket.BrandId = request.BrandId;
                basket.ProductId = request.ProductId;
                basket.Count = request.Count;
                UpdateBasketDto updateBasketDto = _mapper.Map<UpdateBasketDto>(basket);
                return updateBasketDto;
            }
        }
    }
}
