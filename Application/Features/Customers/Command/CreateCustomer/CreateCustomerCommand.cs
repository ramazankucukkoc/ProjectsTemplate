using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Domain.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Command.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public int UserId { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            private readonly CustomerBusinessRules _businessRules;
            private readonly IUserService _userService;


            public CreateCustomerCommandHandler(ICustomerRepository customerRepository,
                IMapper mapper, CustomerBusinessRules businessRules, IUserService userService)
            {
                _userService = userService;
                _customerRepository = customerRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                User user = await _userService.GetById(request.UserId);
                if (user == null) throw new NotFoundException("Böyle kullanıcı bulunamadı o yüzden eklenemez");

                Customer? mappedCustomer = _mapper.Map<Customer>(request);
                Customer addedCustomer = await _customerRepository.AddAsync(mappedCustomer);
                CustomerDto result = _mapper.Map<CustomerDto>(addedCustomer);
                return result;
            }
        }
    }
}
