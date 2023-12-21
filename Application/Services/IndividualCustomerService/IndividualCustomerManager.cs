using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;

namespace Application.Services.IndividualCustomerService
{
    public class IndividualCustomerManager : IIndividualCustomerService
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;

        public IndividualCustomerManager(IIndividualCustomerRepository individualCustomerRepository)
        {
            _individualCustomerRepository = individualCustomerRepository;
        }

        public async Task<string> GetNationalId(int id)
        {
            IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(i => i.Id == id);
            if (individualCustomer is null)
                throw new BusinessException("Individual customer doesn't exists.");
            return individualCustomer.NationalIdentity;
        }
    }
}
