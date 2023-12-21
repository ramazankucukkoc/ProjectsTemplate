using Application.Features.Invoices.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Invoices.Command.CreateInvoice
{
    public class CreateInvoiceCommand : IRequest<CreateInvoiceDto>
    {
        public int ProductId { get; set; }
        public double TotalSum { get; set; }
        public string No { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }

        public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, CreateInvoiceDto>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IMapper _mapper;

            public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            async Task<CreateInvoiceDto> IRequestHandler<CreateInvoiceCommand, CreateInvoiceDto>.Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
            {
                Invoice? mappedInvoice = _mapper.Map<Invoice>(request);
                Invoice createdInvoice = await _invoiceRepository.AddAsync(mappedInvoice);

                CreateInvoiceDto? result = await _invoiceRepository.GetInvoiceDetailsById(createdInvoice.Id);
                return result;
            }
        }
    }
}
