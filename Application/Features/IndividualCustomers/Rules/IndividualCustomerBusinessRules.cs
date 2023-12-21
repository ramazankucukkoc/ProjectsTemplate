using Application.Features.IndividualCustomers.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.IndividualCustomers.Rules
{
    public class IndividualCustomerBusinessRules
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;

        public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
        {
            _individualCustomerRepository = individualCustomerRepository;
        }
        public async Task IndividualCustomerIdShouldExistWhenSelected(int id)
        {
            IndividualCustomer? result = await _individualCustomerRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException(IndividualCustomerBusinessExceptionMessages.IndividualCustomerNotExists);
        }
        public Task IndividualCustomerShouldBeExist(IndividualCustomer? individualCustomer)
        {
            if (individualCustomer is null) throw new BusinessException(IndividualCustomerBusinessExceptionMessages.IndividualCustomerNotExists);
            return Task.CompletedTask;
        }
        public async Task IndividualCustomerNationalIdentityCanNotBeDuplicatedWhenInserted(string nationalIdentity)
        {
            IPaginate<IndividualCustomer> result = await _individualCustomerRepository.GetListAsync(i => i.NationalIdentity == nationalIdentity);
            if (result.Items.Any()) throw new BusinessException(IndividualCustomerBusinessExceptionMessages.IndividualCustomerNationalIdentityAlreadyExists);
        }
        public async Task IndividualCustomerIsActive(bool active)
        {
            if (active == false) throw new BusinessException("Bu Veri silinmiştir.");
        }

        public async Task IndividualCustomerShouldExistWhenRequested(int id, string name)
        {
            var result = await _individualCustomerRepository.Query().Where(i => i.FirstName + " " + i.LastName == name).AnyAsync();
        }
    }
}
