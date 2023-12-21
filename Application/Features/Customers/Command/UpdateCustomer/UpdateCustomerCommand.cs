using Application.Features.Customers.Dtos;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Domain.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Command.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<CustomerDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            private readonly CustomerBusinessRules _customerBusinessRules;
            private readonly IUserService _userService;

            public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper,
                CustomerBusinessRules customerBusinessRules, IUserService userService)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _customerBusinessRules = customerBusinessRules;
                _userService = userService;
            }

            public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                User user = await _userService.GetById(request.UserId);
                if (user == null) throw new NotFoundException("Böyle bir kullanıcı yoktur");

                Customer? customer = await _customerRepository.GetAsync(c => c.Id == request.Id);
                _mapper.Map(request, customer);
                await _customerRepository.UpdateAsync(customer);
                CustomerDto result = _mapper.Map<CustomerDto>(customer);
                return result;
            }
        }

    }
}
