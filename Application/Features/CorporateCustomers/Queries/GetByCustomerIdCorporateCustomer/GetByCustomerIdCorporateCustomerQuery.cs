using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CorporateCustomers.Queries.GetByCustomerIdCorporateCustomer
{
    public class GetByCustomerIdCorporateCustomerQuery : IRequest<CorporateCustomerDto>
    {
        public int CustomerId { get; set; }

        public class GetByCustomerIdCorporateCustomerQueryHandler : IRequestHandler<GetByCustomerIdCorporateCustomerQuery, CorporateCustomerDto>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;
            private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

            public GetByCustomerIdCorporateCustomerQueryHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper,
                CorporateCustomerBusinessRules corporateCustomerBusinessRules)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            }

            public async Task<CorporateCustomerDto> Handle(GetByCustomerIdCorporateCustomerQuery request, CancellationToken cancellationToken)
            {
                CorporateCustomer? corporateCustomer = await _corporateCustomerRepository.GetAsync(b => b.CustomerId == request.CustomerId);
                await _corporateCustomerBusinessRules.CorporateCustomerShouldBeExist(corporateCustomer);
                CorporateCustomerDto corporateCustomerDto = _mapper.Map<CorporateCustomerDto>(corporateCustomer);
                return corporateCustomerDto;
            }
        }
    }
}
