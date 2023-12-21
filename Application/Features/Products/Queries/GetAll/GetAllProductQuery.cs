using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductQuery : IRequest<GetListResponse<GetAllProductDto>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, GetListResponse<GetAllProductDto>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinnessRules _productBusinnessRules;

            public GetAllProductQueryHandler(IProductRepository productRepository,
                IMapper mapper, ProductBusinnessRules productBusinnessRules)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinnessRules = productBusinnessRules;
            }

            public async Task<GetListResponse<GetAllProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Product> products = await _productRepository.GetListAsync(
                    include: x => x.Include(x => x.Category).Include(x => x.Category.ParentCategory),
                    orderBy: x => x.OrderByDescending(x => x.Name));
                if (products.Items.Any()) throw new BusinessException("Ürün bulunmamadı");

                GetListResponse<GetAllProductDto> result = _mapper.Map<GetListResponse<GetAllProductDto>>(products);
                return result;
            }
        }
    }
}
