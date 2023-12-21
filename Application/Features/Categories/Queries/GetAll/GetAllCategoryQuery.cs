using Application.Features.Categories.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoryQuery : IRequest<GetListResponse<GetAllCategoryDto>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, GetListResponse<GetAllCategoryDto>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetAllCategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Category> categories = await _categoryRepository.GetListAsync(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                    include: x => x.Include(x => x.ParentCategory)
                    , orderBy: x => x.OrderBy(x => x.Name));

                GetListResponse<GetAllCategoryDto> result = _mapper.Map<GetListResponse<GetAllCategoryDto>>(categories);
                return result;
            }
        }
    }
}
