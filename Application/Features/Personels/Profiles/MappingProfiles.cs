using Application.Features.Personels.Command.CreatePersonel;
using Application.Features.Personels.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Personels.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Personel, CreatePersonelCommand>().ReverseMap();
            CreateMap<Personel, CreatePersonelDto>().ReverseMap();

        }
    }
}
