using Application.Features.Categories.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Command
{
    public sealed class UpdateCategoryCommand : IRequest<UpdateCategoryDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }
            public async Task<UpdateCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category mappedCategory = _mapper.Map<Category>(request);
                Category updatedCategory = await _categoryRepository.UpdateAsync(mappedCategory);
                UpdateCategoryDto updateCategoryDto = _mapper.Map<UpdateCategoryDto>(updatedCategory);
                return updateCategoryDto;
            }
        }

    }
}
