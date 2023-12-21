using Application.Features.Countries.Command.CreateCountry;
using Application.Features.Countries.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Countries.Profiles
{
    public class MappinProfiles : Profile
    {

        public MappinProfiles()
        {
            CreateMap<Country, CreateCountryCommand>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();


        }
    }
}
