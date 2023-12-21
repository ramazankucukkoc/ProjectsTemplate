using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Command.UpdateBrand
{
    public sealed class UpdateBrandCommand : IRequest<UpdateBrandDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public UpdateBrandCommandHandler(IBrandRepository brandRepository,
                IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<UpdateBrandDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandIdShoulExistsWhenInserted(request.Id);
                Brand? getByIdBrand = await _brandRepository.GetAsync(b => b.Id == request.Id);
                await _brandBusinessRules.BrandActiveShoulExistsWhenInserted(getByIdBrand.Active);
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name.Trim());
                _mapper.Map(request, getByIdBrand);
                await _brandRepository.UpdateAsync(getByIdBrand);
                UpdateBrandDto updateBrandDto = _mapper.Map<UpdateBrandDto>(getByIdBrand);
                return updateBrandDto;
            }
        }

    }
}
