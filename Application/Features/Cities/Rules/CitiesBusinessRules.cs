using Application.Features.Cities.Contants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;

namespace Application.Features.Cities.Rules
{
    public class CitiesBusinessRules
    {
        private readonly ICityRepository _citiesRepository;
        public CitiesBusinessRules(ICityRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }
        public async Task CitiesIdShoulExistsWhenInserted(int id)
        {
            City? result = await _citiesRepository.GetAsync(c => c.Id == id);
            if (result == null) throw new BusinessException(CitiesBusinessExcepitonMessages.CitiesNotExists);
        }
        public async Task CityActiveShoulExistsWhenInserted(bool active)
        {
            if (active == false) throw new BusinessException(CitiesBusinessExcepitonMessages.CitiesNotExists);
        }
    }
}
