using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Command
{
    public sealed class CreateCategoryCommand : IRequest<CreateCategoryDto>
    {
        public string Name { get; set; }//Unique olacak
        public int ParentId { get; set; }
        public sealed class CreateCategeoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly CategoryBusinessRules _categoryBusinessRules;
            private readonly IMapper _mapper;

            public CreateCategeoryCommandHandler(ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules,
                IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _categoryBusinessRules = categoryBusinessRules;
                _mapper = mapper;
            }

            public async Task<CreateCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);
                Category? mappedCategory = _mapper.Map<Category>(request);
                Category category = await _categoryRepository.AddAsync(mappedCategory);
                CreateCategoryDto createCategoryDto = _mapper.Map<CreateCategoryDto>(category);

                return createCategoryDto;
            }
        }

    }
}
