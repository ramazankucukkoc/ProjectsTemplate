using Application.Features.Cities.Dtos;
using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cities.Command.CreateCities
{
    public class CreateCitiesCommand : IRequest<CreateCityDto>
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public class CreateCitiesCommandHandler : IRequestHandler<CreateCitiesCommand, CreateCityDto>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;
            private readonly CitiesBusinessRules _citiesBusinessRules;

            public CreateCitiesCommandHandler(ICityRepository cityRepository,
                IMapper mapper, CitiesBusinessRules citiesBusinessRules)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
                _citiesBusinessRules = citiesBusinessRules;
            }

            public async Task<CreateCityDto> Handle(CreateCitiesCommand request, CancellationToken cancellationToken)
            {

                City? mappedCity = _mapper.Map<City>(request);
                City? createdCity = await _cityRepository.AddAsync(mappedCity);
                CreateCityDto createCitiesDto = _mapper.Map<CreateCityDto>(createdCity);
                return createCitiesDto;
            }
        }

    }
}
