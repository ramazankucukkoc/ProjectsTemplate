using Application.Features.CorporateCustomers.Command.CreateCorporateCustomer;
using Application.Features.CorporateCustomers.Command.DeleteCorporateCustomer;
using Application.Features.CorporateCustomers.Command.UpdateCorporateCustomer;
using Application.Features.CorporateCustomers.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.CorporateCustomers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CorporateCustomer, CreateCorporateCustomerCommand>().ReverseMap();
            CreateMap<CorporateCustomer, UpdateCorporateCustomerCommand>().ReverseMap();
            CreateMap<CorporateCustomer, DeleteCorporateCustomerCommand>().ReverseMap();

            CreateMap<CorporateCustomer, DeleteCorporateCustomerDto>().ReverseMap();
            CreateMap<CorporateCustomer, CreateCorporateCustomerDto>().ReverseMap();
            CreateMap<CorporateCustomer, DeleteCorporateCustomerDto>().ReverseMap();

            CreateMap<CorporateCustomer, CorporateCustomerDto>().ReverseMap();

            CreateMap<IPaginate<CorporateCustomer>, GetListResponse<CorporateCustomerDto>>().ReverseMap();
        }
    }
}
