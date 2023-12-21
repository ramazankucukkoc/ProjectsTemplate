using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Categories.Queries.GetById
{
    public sealed class GetByIdCategoryQuery : IRequest<GetByIdCategoryDto>
    {
        public int Id { get; set; }

        public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;

            public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository,
                IMapper mapper, CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<GetByIdCategoryDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.CategoryCanNotBeDuplicatedWhenInserted(request.Id);
                Category? category = await _categoryRepository.GetAsync(predicate: x => x.Id == request.Id, include: x => x.Include(x => x.ParentCategory));
                GetByIdCategoryDto getByIdCategoryDto = _mapper.Map<GetByIdCategoryDto>(category);
                return getByIdCategoryDto;
            }
        }
    }
}
