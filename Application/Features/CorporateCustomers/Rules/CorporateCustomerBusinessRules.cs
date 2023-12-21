using Application.Features.CorporateCustomers.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.CorporateCustomers.Rules
{
    public class CorporateCustomerBusinessRules
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;

        public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
        }
        public async Task CorporateCustomerIdShouldExistWhenSelected(int id)
        {
            CorporateCustomer? corporateCustomer = await _corporateCustomerRepository.GetAsync(c => c.Id == id);
            if (corporateCustomer is null) throw new BusinessException(CorporateCustomerBusinessRulesMessages.CorporateCustomerExists);
        }
        public Task CorporateCustomerShouldBeExist(CorporateCustomer? corporateCustomer)
        {
            if (corporateCustomer is null) throw new BusinessException(CorporateCustomerBusinessRulesMessages.CorporateCustomerExists);
            return Task.CompletedTask;
        }
        public async Task CorporateCustomerTaxNoCanNotBeDuplicatedWhenInserted(string taxNo)
        {
            IPaginate<CorporateCustomer> result = await _corporateCustomerRepository.GetListAsync(c => c.TaxNo == taxNo);
            if (result.Items.Any()) throw new BusinessException(CorporateCustomerBusinessRulesMessages.CorporateCustomerTaxNoNotExists);
        }

    }
}
