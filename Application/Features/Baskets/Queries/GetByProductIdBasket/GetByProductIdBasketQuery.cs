using Application.Features.Baskets.Dtos;
using Application.Features.Baskets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Baskets.Queries.GetByProductIdBasket
{
    public class GetByProductIdBasketQuery : IRequest<GetListResponse<BasketListDto>>
    {
        public PageRequest PageRequest { get; set; }
        public int ProductId { get; set; }

        public class GetByProductIdBasketQueryHandler : IRequestHandler<GetByProductIdBasketQuery, GetListResponse<BasketListDto>>
        {
            private readonly IMapper _mapper;
            private readonly IBasketRepository _basketRepository;
            private readonly BasketBusinessRules _basketBusinessRules;

            public GetByProductIdBasketQueryHandler(IMapper mapper, IBasketRepository basketRepository
                , BasketBusinessRules basketBusinessRules)
            {
                _basketBusinessRules = basketBusinessRules;
                _mapper = mapper;
                _basketRepository = basketRepository;
            }

            public async Task<GetListResponse<BasketListDto>> Handle(GetByProductIdBasketQuery request, CancellationToken cancellationToken)
            {

                IPaginate<BasketListDto> baskets = await _basketRepository.GetAllProductBaskets(request.ProductId);

                if (baskets.Items.Any() == false) throw new BusinessException("Ürün bulunmamaktadır!");

                GetListResponse<BasketListDto> result = _mapper.Map<GetListResponse<BasketListDto>>(baskets);
                return result;
            }
        }
    }
}
