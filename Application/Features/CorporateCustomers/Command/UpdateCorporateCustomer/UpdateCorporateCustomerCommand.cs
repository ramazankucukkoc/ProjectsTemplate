using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CorporateCustomers.Command.UpdateCorporateCustomer
{
    public class UpdateCorporateCustomerCommand : IRequest<UpdateCorporateDto>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; }

        public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, UpdateCorporateDto>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;
            private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

            public UpdateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository,
                IMapper mapper, CorporateCustomerBusinessRules corporateCustomerBusinessRules)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            }

            public async Task<UpdateCorporateDto> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _corporateCustomerBusinessRules.CorporateCustomerTaxNoCanNotBeDuplicatedWhenInserted(request.TaxNo);
                CorporateCustomer mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
                CorporateCustomer updatedCorporateCustomer = await _corporateCustomerRepository.UpdateAsync(mappedCorporateCustomer);
                UpdateCorporateDto updateCorporateDto = _mapper.Map<UpdateCorporateDto>(updatedCorporateCustomer);
                return updateCorporateDto;
            }
        }
    }
}
