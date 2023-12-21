using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetAllDynamic
{
    public class GetAllProductByDynamicQuery : IRequest<GetListResponse<GetAllProductDto>>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }

        public class GetAllProductByDynamicQueryHandler : IRequestHandler<GetAllProductByDynamicQuery, GetListResponse<GetAllProductDto>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetAllProductByDynamicQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetAllProductDto>> Handle(GetAllProductByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Product> products = await _productRepository.GetListByDynamicAsync(
                    request.Dynamic,
                    p => p.Include(p => p.Category)
                    .Include(p => p.Category.ParentCategory)
                    , request.PageRequest.Page,
                   request.PageRequest.PageSize);

                if (products.Items.Any()) throw new BusinessException("Ürünler bulunamadı");

                GetListResponse<GetAllProductDto> result = _mapper.Map<GetListResponse<GetAllProductDto>>(products);
                return result;
            }
        }
    }
}
