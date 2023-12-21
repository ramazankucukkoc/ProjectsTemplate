using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetListBrand
{
    public class GetListBrandQuery : IRequest<GetListResponse<BrandListDto>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListResponse<BrandListDto>>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<BrandListDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Brand> brands = await _brandRepository.GetListAsync(b => b.Active == true,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                GetListResponse<BrandListDto> mappedBrandListModel = _mapper.Map<GetListResponse<BrandListDto>>(brands);
                return mappedBrandListModel;
            }
        }
    }
}
