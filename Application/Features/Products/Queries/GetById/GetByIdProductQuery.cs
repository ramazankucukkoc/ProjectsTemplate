using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetById
{
    public sealed class GetByIdProductQuery : IRequest<GetByIdProductDto>
    {
        public int Id { get; set; }

        public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinnessRules _businnessRules;

            public GetByIdProductQueryHandler(IProductRepository productRepository,
                IMapper mapper, ProductBusinnessRules businnessRules)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _businnessRules = businnessRules;
            }

            public async Task<GetByIdProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
            {
                await _businnessRules.ProductCanNotBeDuplicatedWhenInserted(request.Id);
                Product? product = await _productRepository.GetAsync(x => x.Id == request.Id, include: x => x.Include(x => x.Category));
                GetByIdProductDto getByIdProductDto = _mapper.Map<GetByIdProductDto>(product);
                return getByIdProductDto;
            }
        }
    }
}
