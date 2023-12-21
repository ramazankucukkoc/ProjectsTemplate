using Application.Features.Addresss.Command.CreateAddress;
using Application.Features.Addresss.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Addresss.Profiles
{
    public class MappingsProfiles : Profile
    {
        public MappingsProfiles()
        {
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<Address, CreateAddressDto>().ReverseMap();

            CreateMap<IPaginate<GetByUserIdAddressDto>, GetListResponse<GetByUserIdAddressDto>>().ReverseMap();
        }
    }
}
