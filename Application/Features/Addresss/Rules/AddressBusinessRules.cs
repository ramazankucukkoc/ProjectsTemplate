using Application.Features.Addresss.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;

namespace Application.Features.Addresss.Rules
{
    public class AddressBusinessRules
    {
        private readonly IAddressRepository _addressRepository;

        public AddressBusinessRules(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task AddressIdShoulExistsWhenInserted(int id)
        {
            Address? result = await _addressRepository.GetAsync(a => a.Id == id);
            if (result == null) throw new BusinessException(AddressBusinessExceptionMessages.AddressExists);
        }
        public async Task AddressActiveShoulExistsWhenInserted(bool active)
        {
            if (active == false) throw new BusinessException(AddressBusinessExceptionMessages.AddressExists);
        }

    }
}
