using Application.Features.ProductBranchs.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.ProductBranchs.Command.CreateProductBranch
{
    public sealed class CreateProductBranchCommand : IRequest<CreateProductBranchDto>
    {
        public string Name { get; set; }
        public CitiesPlate Cities { get; set; }
        public class CreateProductBranchCommandHandler : IRequestHandler<CreateProductBranchCommand, CreateProductBranchDto>
        {
            private readonly IProductBranchRepository _productBranchRepository;
            private readonly IMapper _mapper;

            public CreateProductBranchCommandHandler(IProductBranchRepository productBranchRepository, IMapper mapper)
            {
                _productBranchRepository = productBranchRepository;
                _mapper = mapper;
            }

            public async Task<CreateProductBranchDto> Handle(CreateProductBranchCommand request, CancellationToken cancellationToken)
            {
                ProductBranch mappedProductBranch = _mapper.Map<ProductBranch>(request);
                ProductBranch createProductBranch = await _productBranchRepository.AddAsync(mappedProductBranch);
                CreateProductBranchDto createProductBranchDto = _mapper.Map<CreateProductBranchDto>(createProductBranch);
                return createProductBranchDto;
            }
        }
    }
}
