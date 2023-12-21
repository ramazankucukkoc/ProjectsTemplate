using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customers.Queries.GetByUserIdCustomer
{
    public class GetByUserIdCustomerQuery : IRequest<CustomerDto>
    {
        public int UserId { get; set; }

        public class GetByUserIdCustomerQueryHandler : IRequestHandler<GetByUserIdCustomerQuery, CustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            private readonly CustomerBusinessRules _customerBusinessRules;

            public GetByUserIdCustomerQueryHandler(ICustomerRepository customerRepository,
                IMapper mapper, CustomerBusinessRules customerBusinessRules)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _customerBusinessRules = customerBusinessRules;
            }

            public async Task<CustomerDto> Handle(GetByUserIdCustomerQuery request, CancellationToken cancellationToken)
            {
                Customer? customer = await _customerRepository.GetAsync(c => c.UserId == request.UserId, include: u => u.Include(u => u.User));
                await _customerBusinessRules.CustomerShouldExist(customer);
                CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);
                return customerDto;
            }
        }
    }
}
