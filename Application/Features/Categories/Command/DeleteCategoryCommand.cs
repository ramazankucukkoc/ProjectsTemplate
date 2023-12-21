using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Command
{
    public sealed class DeleteCategoryCommand : IRequest<DeleteCategoryDto>
    {
        public int Id { get; set; }
        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryDto>
        {
            private readonly IMapper _mapper;
            private readonly ICategoryRepository _categoryRepository;
            private readonly CategoryBusinessRules _categoryBusinessRules;
            public DeleteCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository,
                CategoryBusinessRules categoryBusinessRules)
            {
                _mapper = mapper;
                _categoryRepository = categoryRepository;
                _categoryBusinessRules = categoryBusinessRules;
            }
            public async Task<DeleteCategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.CategoryCanNotBeDuplicatedWhenInserted(request.Id);
                Category? category = await _categoryRepository.GetAsync(x => x.Id == request.Id);
                Category deletedCategory = await _categoryRepository.DeleteAsync(category);
                DeleteCategoryDto deleteCategoryDto = _mapper.Map<DeleteCategoryDto>(deletedCategory);
                return deleteCategoryDto;
            }
        }
    }
}
