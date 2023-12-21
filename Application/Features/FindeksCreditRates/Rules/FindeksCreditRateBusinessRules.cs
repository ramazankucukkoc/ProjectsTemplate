using Application.Features.FindeksCreditRates.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;

namespace Application.Features.FindeksCreditRates.Rules
{
    public class FindeksCreditRateBusinessRules
    {
        private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;

        public FindeksCreditRateBusinessRules(IFindeksCreditRateRepository findeksCreditRateRepository)
        {
            _findeksCreditRateRepository = findeksCreditRateRepository;
        }
        public async Task FindeksCreditRateIdShouldExistWhenSelected(int id)
        {
            FindeksCreditRate? findeksCreditRate = await _findeksCreditRateRepository.GetAsync(f => f.Id == id);
            if (findeksCreditRate is null) throw new BusinessException(FindeksCreditRateBusinessRulesMessages.FindeksCreditRateExists);
        }
        public Task FindeksCreditShouldBeExist(FindeksCreditRate? findeksCreditRate)
        {
            if (findeksCreditRate is null) throw new BusinessException(FindeksCreditRateBusinessRulesMessages.FindeksCreditRateExists);

            return Task.CompletedTask;
        }
    }
}
