using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.IndividualCustomers.Queries.GetByCustomerIdIndividualCustomer
{
    public class GetByCustomerIdIndividualCustomerQuery : IRequest<IndividualCustomerDto>
    {
        public int CustomerId { get; set; }

        public class GetByCustomerIdIndividualCustomerQueryHandler : IRequestHandler<GetByCustomerIdIndividualCustomerQuery, IndividualCustomerDto>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;
            private readonly IndividualCustomerBusinessRules _businessRules;

            public GetByCustomerIdIndividualCustomerQueryHandler(IIndividualCustomerRepository individualCustomerRepository,
                IMapper mapper, IndividualCustomerBusinessRules businessRules)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<IndividualCustomerDto> Handle(GetByCustomerIdIndividualCustomerQuery request, CancellationToken cancellationToken)
            {
                IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(b => b.CustomerId == request.CustomerId);
                await _businessRules.IndividualCustomerShouldBeExist(individualCustomer);
                IndividualCustomerDto individualCustomerDto = _mapper.Map<IndividualCustomerDto>(individualCustomer);
                return individualCustomerDto;
            }
        }
    }
}
