using Application.Features.ProductBranchs.Command.CreateProductBranch;
using Application.Features.ProductBranchs.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.ProductBranchs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductBranch, CreateProductBranchDto>().ReverseMap();
            CreateMap<ProductBranch, CreateProductBranchCommand>().ReverseMap();

        }
    }
}
