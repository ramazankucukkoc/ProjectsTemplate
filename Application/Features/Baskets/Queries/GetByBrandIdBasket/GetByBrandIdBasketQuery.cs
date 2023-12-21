using Application.Features.Baskets.Dtos;
using Application.Features.Baskets.Rules;
using Application.Services.BrandService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Baskets.Queries.GetByBrandIdBasket
{
    public class GetByBrandIdBasketQuery : IRequest<GetListResponse<GetByBrandIdBasketDto>>
    {
        public int BrandId { get; set; }

        public class GetByBrandIdBasketQueryHadnler : IRequestHandler<GetByBrandIdBasketQuery, GetListResponse<GetByBrandIdBasketDto>>
        {
            private readonly IBasketRepository _basketRepository;
            private readonly IMapper _mapper;
            private readonly BasketBusinessRules _basketBusinessRules;
            private readonly IBrandService _brandService;

            public GetByBrandIdBasketQueryHadnler(IBasketRepository basketRepository, IMapper mapper, BasketBusinessRules basketBusinessRules, IBrandService brandService)
            {
                _basketRepository = basketRepository;
                _mapper = mapper;
                _basketBusinessRules = basketBusinessRules;
                _brandService = brandService;
            }

            public async Task<GetListResponse<GetByBrandIdBasketDto>> Handle(GetByBrandIdBasketQuery request, CancellationToken cancellationToken)
            {
                await _basketBusinessRules.BasketBrandIdControl(request.BrandId);
                Brand brand = await _brandService.GetById(request.BrandId);
                await _basketBusinessRules.BasketBrandIdActiveShoulExistsWhenInserted(brand.Active);

                IPaginate<Basket>? basket = await _basketRepository.GetListAsync(b => b.BrandId == request.BrandId && b.Active == true,
                    include: b => b.Include(b => b.Product).ThenInclude(b => b.Category)
                    .ThenInclude(b => b.ParentCategory).Include(b => b.User).Include(b => b.Brand));

                GetListResponse<GetByBrandIdBasketDto> mappedBaskets = _mapper.Map<GetListResponse<GetByBrandIdBasketDto>>(basket);
                return mappedBaskets;

            }
        }
    }
}
