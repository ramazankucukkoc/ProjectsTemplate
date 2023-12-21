using Application.Features.Baskets.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Baskets.Queries.GetList
{
    public class GetListBasketQuery : IRequest<GetListResponse<BasketListDto>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListBasketQueryHandler : IRequestHandler<GetListBasketQuery, GetListResponse<BasketListDto>>
        {
            private readonly IBasketRepository _basketRepository;
            private readonly IMapper _mapper;

            public GetListBasketQueryHandler(IBasketRepository basketRepository, IMapper mapper)
            {
                _basketRepository = basketRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<BasketListDto>> Handle(GetListBasketQuery request, CancellationToken cancellationToken)
            {
                IPaginate<BasketListDto> getAllBasktes = await _basketRepository.GetAllBaskets(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                GetListResponse<BasketListDto> result = _mapper.Map<GetListResponse<BasketListDto>>(getAllBasktes);

                return result;

            }
        }
    }
}
