using Application.Features.Sales.Dtos;
using Application.Features.Sales.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Sales.Command.CreateSale
{
    public sealed class CreateSaleCommand : IRequest<CreateSaleDto>
    {
        public int Quantity { get; set; }//Adet
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int PersonelId { get; set; }

        public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, CreateSaleDto>
        {
            private readonly ISaleRepository _saleRepository;
            private readonly IMapper _mapper;
            private readonly SaleBusinessRules _businessRules;

            public CreateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, SaleBusinessRules businessRules)
            {
                _saleRepository = saleRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreateSaleDto> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.PersonelIdControl(request.PersonelId);
                await _businessRules.CustomerIdControl(request.CustomerId);
                await _businessRules.ProductIdControl(request.ProductId);
                Sale? mappedSale = _mapper.Map<Sale>(request);
                Sale createdSale = await _saleRepository.AddAsync(mappedSale);
                CreateSaleDto? result = await _saleRepository.GetById(createdSale.Id);
                if (result is null) throw new NotFoundException("Bu ürününün satışı yapılammaış");

                return result;
            }
        }
    }
}
