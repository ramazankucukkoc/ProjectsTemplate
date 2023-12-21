using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customers.Queries.GetByIdCustomer
{
    public class GetByIdCustomerQuery : IRequest<CustomerDto>
    {
        public int Id { get; set; }
        public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, CustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            private readonly CustomerBusinessRules _customerBusinessRules;

            public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository,
                IMapper mapper, CustomerBusinessRules customerBusinessRules)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _customerBusinessRules = customerBusinessRules;
            }

            public async Task<CustomerDto> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
            {
                Customer? customer = await _customerRepository.GetAsync(b => b.Id == request.Id,
                    include: x => x.Include(u => u.User));
                await _customerBusinessRules.CustomerIdShouldExist(customer.Id);
                CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);
                return customerDto;
            }
        }
    }
}
