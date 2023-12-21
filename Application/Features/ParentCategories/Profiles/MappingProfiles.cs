using Application.Features.ParentCategories.Command;
using Application.Features.ParentCategories.Dtos;
using Domain.Entities;
using Profile = AutoMapper.Profile;

namespace Application.Features.ParentCategories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ParentCategory, CreateParentCategoryCommand>().ReverseMap();
            CreateMap<ParentCategory, CreateParentCategoryDto>().ReverseMap();
        }
    }
}
