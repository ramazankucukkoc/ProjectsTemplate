using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;

namespace Application.Features.Customers.Rules
{
    public class CustomerBusinessRules
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBusinessRules(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task CustomerIdShouldExist(int id)
        {
            Customer? customer = await _customerRepository.GetAsync(c => c.Id == id);
            if (customer is null) throw new BusinessException("Customer doesn't exists.");
        }
        public Task CustomerShouldExist(Customer? customer)
        {

            if (customer is null) throw new BusinessException("Customer doesn't exists.");
            return Task.CompletedTask;
        }


    }
}
