using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CorporateCustomers.Command.CreateCorporateCustomer
{
    public sealed class CreateCorporateCustomerCommand : IRequest<CreateCorporateCustomerDto>
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; }
        public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreateCorporateCustomerDto>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;
            private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;
            private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

            public CreateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository,
                IMapper mapper, IFindeksCreditRateRepository findeksCreditRateRepository,
                CorporateCustomerBusinessRules corporateCustomerBusinessRules)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _findeksCreditRateRepository = findeksCreditRateRepository;
                _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            }

            public async Task<CreateCorporateCustomerDto> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _corporateCustomerBusinessRules.CorporateCustomerTaxNoCanNotBeDuplicatedWhenInserted(request.TaxNo);
                CorporateCustomer mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
                CorporateCustomer addedCorporateCustomer = await _corporateCustomerRepository.AddAsync(mappedCorporateCustomer);
                await _findeksCreditRateRepository.AddAsync(new FindeksCreditRate { CustomerId = addedCorporateCustomer.CustomerId });

                CreateCorporateCustomerDto createCorporateCustomerDto = _mapper.Map<CreateCorporateCustomerDto>(addedCorporateCustomer);
                return createCorporateCustomerDto;

            }
        }

    }
}
