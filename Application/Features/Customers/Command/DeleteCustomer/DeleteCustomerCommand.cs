using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Command.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<CustomerDto>
    {
        public int Id { get; set; }

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, CustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            private readonly CustomerBusinessRules _businessRules;

            public DeleteCustomerCommandHandler(ICustomerRepository customerRepository,
                IMapper mapper, CustomerBusinessRules businessRules)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.CustomerIdShouldExist(request.Id);
                Customer mappedCustomer = _mapper.Map<Customer>(request);
                Customer deletedCustomer = await _customerRepository.DeleteAsync(mappedCustomer);
                CustomerDto result = _mapper.Map<CustomerDto>(deletedCustomer);
                return result;
            }
        }
    }
}
