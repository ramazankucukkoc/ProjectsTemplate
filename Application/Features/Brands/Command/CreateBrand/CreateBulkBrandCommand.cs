using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Command.CreateBrand
{
    public sealed class CreateBulkBrandCommand : IRequest<List<CreateBrandDto>>
    {
        public List<string> NameList { get; set; }

        public class CreateBulkBrandCommandHandler : IRequestHandler<CreateBulkBrandCommand, List<CreateBrandDto>>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly BrandBusinessRules _brandBusinessRules;

            public CreateBulkBrandCommandHandler(IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<List<CreateBrandDto>> Handle(CreateBulkBrandCommand request, CancellationToken cancellationToken)
            {
                if (request.NameList == null || request.NameList.Count == 0)
                    await _brandBusinessRules.BrandNameListCanNotBeDuplicatedWhenInserted(request.NameList);

                List<Brand> mappedListBrand = request.NameList.Select(x => new Brand { Name = x, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }).ToList();
                List<Brand> createListBrand = await _brandRepository.AddRangeAsync(mappedListBrand);
                List<CreateBrandDto> result = createListBrand.Select(x => new CreateBrandDto { Id = x.Id, Name = x.Name }).ToList();
                return result;
            }
        }
    }
}
