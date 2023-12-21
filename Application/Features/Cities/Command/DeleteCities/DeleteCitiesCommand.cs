using Application.Features.Cities.Dtos;
using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cities.Command.DeleteCities
{
    public class DeleteCitiesCommand : IRequest<DeleteCityDto>
    {
        public int Id { get; set; }

        public class DeleteCitiesCommandHandler : IRequestHandler<DeleteCitiesCommand, DeleteCityDto>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;
            private readonly CitiesBusinessRules _citiesBusinessRules;

            public DeleteCitiesCommandHandler(ICityRepository cityRepository,
                IMapper mapper, CitiesBusinessRules citiesBusinessRules)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
                _citiesBusinessRules = citiesBusinessRules;
            }

            public async Task<DeleteCityDto> Handle(DeleteCitiesCommand request, CancellationToken cancellationToken)
            {
                await _citiesBusinessRules.CitiesIdShoulExistsWhenInserted(request.Id);
                City? getByIdcity = await _cityRepository.GetAsync(c => c.Id == request.Id);
                getByIdcity.Active = false;
                City deletedCity = await _cityRepository.UpdateAsync(getByIdcity);
                DeleteCityDto deleteCityDto = _mapper.Map<DeleteCityDto>(deletedCity);
                return deleteCityDto;
            }
        }

    }
}
