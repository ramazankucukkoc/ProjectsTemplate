using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Command.CreateBrand
{
    public sealed class CreateBrandCommand : IRequest<CreateBrandDto>,ILoggableRequest
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreateBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public CreateBrandCommandHandler(IBrandRepository brandRepository,
                IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }
            public async Task<CreateBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name.Trim());
                Brand? mappedBrand = _mapper.Map<Brand>(request);
                Brand createBrand = await _brandRepository.AddAsync(mappedBrand);
                CreateBrandDto createBrandDto = _mapper.Map<CreateBrandDto>(createBrand);
                return createBrandDto;
            }
        }
    }
}
