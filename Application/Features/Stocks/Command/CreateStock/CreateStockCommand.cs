using Application.Features.Stocks.Dtos;
using Application.Services.ProductService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Stocks.Command.CreateStock
{
    public class CreateStockCommand : IRequest<CreateStockDto>
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, CreateStockDto>
        {
            private readonly IStockRepository _stockRepository;
            private readonly IMapper _mapper;
            private readonly IProductService _productService;

            public CreateStockCommandHandler(IStockRepository stockRepository, IMapper mapper, IProductService productService)
            {
                _stockRepository = stockRepository;
                _mapper = mapper;
                _productService = productService;
            }

            public async Task<CreateStockDto> Handle(CreateStockCommand request, CancellationToken cancellationToken)
            {
                Stock? mappedStock = _mapper.Map<Stock>(request);
                Stock createdStock = await _stockRepository.AddAsync(mappedStock);
                Product? product = await _productService.GetById(createdStock.ProductId);

                CreateStockDto createStockDto = _mapper.Map<CreateStockDto>(createdStock);
                createStockDto.ProductName = product.Name;

                return createStockDto;

            }
        }

    }
}
