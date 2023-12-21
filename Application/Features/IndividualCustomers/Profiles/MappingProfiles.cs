using Application.Features.IndividualCustomers.Command.CreateIndividualCustomer;
using Application.Features.IndividualCustomers.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.IndividualCustomers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IndividualCustomer, CreateIndividualCustomerCommand>().ReverseMap();
            CreateMap<IndividualCustomer, CreateIndividualCustomerDto>().ReverseMap();

            CreateMap<IndividualCustomer, CreateIndividualCustomerCommand>().ReverseMap();


        }
    }
}
