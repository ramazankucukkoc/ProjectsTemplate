using Application.Features.Customers.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Customers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(c => c.CustomerUser, dest => dest.MapFrom(c => c.User))
                .ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
