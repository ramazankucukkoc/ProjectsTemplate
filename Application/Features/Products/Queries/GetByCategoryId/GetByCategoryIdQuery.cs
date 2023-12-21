using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetByCategoryId
{
    public class GetByCategoryIdQuery : IRequest<GetListResponse<GetByCategoryIdDto>>
    {
        public int CategoryId { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetByCategoryIdQueryHandler : IRequestHandler<GetByCategoryIdQuery, GetListResponse<GetByCategoryIdDto>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetByCategoryIdQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }
            public async Task<GetListResponse<GetByCategoryIdDto>> Handle(GetByCategoryIdQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Product> products = await _productRepository.GetListAsync(p => p.CategoryId == request.CategoryId
                 , include: p => p.Include(p => p.Category),
                 index: request.PageRequest.Page,
                 size: request.PageRequest.PageSize);

                if (products.Items.Any()) throw new BusinessException("Ürün bulunmamadı");

                GetListResponse<GetByCategoryIdDto> result = _mapper.Map<GetListResponse<GetByCategoryIdDto>>(products);
                return result;
            }
        }
    }
}
