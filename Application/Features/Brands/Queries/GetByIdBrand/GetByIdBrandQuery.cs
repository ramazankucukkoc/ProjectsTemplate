using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetByIdBrand
{
    public sealed class GetByIdBrandQuery : IRequest<BrandDto>
    {
        public int Id { get; set; }

        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public GetByIdBrandQueryHandler(IBrandRepository brandRepository,
                IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<BrandDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandIdShoulExistsWhenInserted(request.Id);
                Brand? brand = await _brandRepository.GetAsync(b => b.Id == request.Id);
                await _brandBusinessRules.BrandActiveShoulExistsWhenInserted(brand.Active);
                BrandDto brandDto = _mapper.Map<BrandDto>(brand);
                return brandDto;
            }
        }
    }
}
