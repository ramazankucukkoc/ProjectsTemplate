using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Command.DeleteBrand
{
    public sealed class DeleteBrandCommand : IRequest<DeleteBrandDto>
    {
        public int Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public DeleteBrandCommandHandler(IBrandRepository brandRepository,
                IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<DeleteBrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandIdShoulExistsWhenInserted(request.Id);
                Brand? getByIdBrand = await _brandRepository.GetAsync(x => x.Id == request.Id);
                getByIdBrand.Active = false;

                Brand deletedBrand = await _brandRepository.UpdateAsync(getByIdBrand);
                DeleteBrandDto deleteBrandDto = _mapper.Map<DeleteBrandDto>(deletedBrand);
                return deleteBrandDto;
            }
        }
    }
}
