using Application.Features.Cities.Dtos;
using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cities.Command.UpdateCities
{
    public class UpdateCitiesCommand : IRequest<UpdateCityDto>
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public class UpdateCitiesCommandHandler : IRequestHandler<UpdateCitiesCommand, UpdateCityDto>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;
            private readonly CitiesBusinessRules _citiesBusinessRules;

            public UpdateCitiesCommandHandler(ICityRepository cityRepository,
                IMapper mapper, CitiesBusinessRules citiesBusinessRules)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
                _citiesBusinessRules = citiesBusinessRules;
            }

            public async Task<UpdateCityDto> Handle(UpdateCitiesCommand request, CancellationToken cancellationToken)
            {
                await _citiesBusinessRules.CitiesIdShoulExistsWhenInserted(request.Id);
                City? getByIdCity = _mapper.Map<City>(request);
                await _citiesBusinessRules.CityActiveShoulExistsWhenInserted(getByIdCity.Active);
                City mappedCity = _mapper.Map<City>(request);
                City updateCity = await _cityRepository.UpdateAsync(mappedCity);
                UpdateCityDto updateCityDto = _mapper.Map<UpdateCityDto>(updateCity);
                return updateCityDto;

            }
        }

    }
}
