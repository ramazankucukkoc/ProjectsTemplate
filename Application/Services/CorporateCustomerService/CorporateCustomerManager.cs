using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;

namespace Application.Services.CorporateCustomerService
{
    public class CorporateCustomerManager : ICorporateCustomerService
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;

        public CorporateCustomerManager(ICorporateCustomerRepository corporateCustomerRepository)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
        }

        public async Task<string> GetTaxNumber(int id)
        {
            var customer = await _corporateCustomerRepository.GetAsync(c => c.Id == id);
            if (customer is null) throw new BusinessException("Customer doesn't exists.");

            return customer.TaxNo;

        }
    }
}
