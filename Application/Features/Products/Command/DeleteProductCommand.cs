using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Command
{
    public sealed class DeleteProductCommand : IRequest<DeleteProductDto>
    {
        public int Id { get; set; }
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinnessRules _businnessRules;

            public DeleteProductCommandHandler(IProductRepository productRepository,
                IMapper mapper, ProductBusinnessRules businnessRules)
                => (_productRepository, _mapper, _businnessRules) = (productRepository, mapper, businnessRules);
            public async Task<DeleteProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                await _businnessRules.ProductCanNotBeDuplicatedWhenInserted(request.Id);
                Product? product = await _productRepository.GetAsync(x => x.Id == request.Id);
                Product productDeleted = await _productRepository.DeleteAsync(product);
                DeleteProductDto productDto = _mapper.Map<DeleteProductDto>(productDeleted);
                return productDto;
            }
        }
    }
}
