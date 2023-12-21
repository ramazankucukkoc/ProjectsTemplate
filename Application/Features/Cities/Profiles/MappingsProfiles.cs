using Application.Features.Cities.Command.CreateCities;
using Application.Features.Cities.Command.DeleteCities;
using Application.Features.Cities.Command.UpdateCities;
using Application.Features.Cities.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Cities.Profiles
{
    public class MappingsProfiles : Profile
    {
        public MappingsProfiles()
        {
            CreateMap<City, CreateCitiesCommand>().ReverseMap();
            CreateMap<City, CreateCityDto>().ReverseMap();
            CreateMap<City, DeleteCitiesCommand>().ReverseMap();
            CreateMap<City, DeleteCityDto>().ReverseMap();
            CreateMap<City, UpdateCityDto>().ReverseMap();
            CreateMap<City, UpdateCitiesCommand>().ReverseMap();

        }
    }
}
