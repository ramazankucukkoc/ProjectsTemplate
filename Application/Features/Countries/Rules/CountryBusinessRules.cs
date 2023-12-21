using Application.Services.Repositories;

namespace Application.Features.Countries.Rules
{
    public class CountryBusinessRules
    {
        private readonly ICountryRepository _countryRepository;

        public CountryBusinessRules(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
    }
}
