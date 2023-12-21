using Application.Features.Customers.Rules;
using Application.Features.Personels.Rules;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;

namespace Application.Features.Sales.Rules
{
    public class SaleBusinessRules
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ProductBusinnessRules _productBusinnessRules;
        private readonly CustomerBusinessRules _customerBusinessRules;
        private readonly PersonelBusinessRules _personelBusinessRules;

        public SaleBusinessRules(ISaleRepository saleRepository,
            ProductBusinnessRules productBusinnessRules, CustomerBusinessRules customerBusinessRules, PersonelBusinessRules personelBusinessRules)
        {
            _saleRepository = saleRepository;
            _productBusinnessRules = productBusinnessRules;
            _customerBusinessRules = customerBusinessRules;
            _personelBusinessRules = personelBusinessRules;
        }

        public async Task SaleIdControl(int saleId)
        {
            Sale? sale = await _saleRepository.GetAsync(s => s.Id == saleId);
            if (sale is null) throw new BusinessException("Satış işlemi bulunamadı");
        }
        public async Task ProductIdControl(int productId)
        {
            await _productBusinnessRules.ProductCanNotBeDuplicatedWhenInserted(productId);
        }
        public async Task CustomerIdControl(int customerId)
        {
            await _customerBusinessRules.CustomerIdShouldExist(customerId);
        }
        public async Task PersonelIdControl(int personelId)
        {
            await _personelBusinessRules.PersonelIdControl(personelId);
        }

    }
}
