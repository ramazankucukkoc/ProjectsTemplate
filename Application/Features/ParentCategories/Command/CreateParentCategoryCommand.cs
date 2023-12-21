using Application.Features.ParentCategories.Dtos;
using Application.Features.ParentCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ParentCategories.Command
{
    public class CreateParentCategoryCommand : IRequest<CreateParentCategoryDto>
    {
        public string Name { get; set; }

        public class CreateParentCategoryCommandHandler : IRequestHandler<CreateParentCategoryCommand, CreateParentCategoryDto>
        {
            private readonly IParentCategoryRepository _parentCategoriesRepository;
            private readonly IMapper _mapper;
            private readonly ParentCategoriesBusinessRules _parentCategoriesBusinessRules;

            public CreateParentCategoryCommandHandler(IParentCategoryRepository parentCategoriesRepository, 
                IMapper mapper, ParentCategoriesBusinessRules parentCategoriesBusinessRules)
            {
                _parentCategoriesRepository = parentCategoriesRepository;
                _mapper = mapper;
                _parentCategoriesBusinessRules = parentCategoriesBusinessRules;
            }

            public async Task<CreateParentCategoryDto> Handle(CreateParentCategoryCommand request, CancellationToken cancellationToken)
            {
                await _parentCategoriesBusinessRules.ParentCategoryNameCanNotBeDuplicatedWhenInserted(request.Name);
                ParentCategory? mappedParentCategory = _mapper.Map<ParentCategory>(request);
                ParentCategory addedParentCategory = await _parentCategoriesRepository.AddAsync(mappedParentCategory);
                CreateParentCategoryDto createParentCategoryDto = _mapper.Map<CreateParentCategoryDto>(addedParentCategory);
                return createParentCategoryDto;
            }
        }
    }
}
