using Application.Features.Categories.Command;
using Application.Features.Categories.Dtos;
using Core.Persistence.Paging;
using Domain.Entities;
using Profile = AutoMapper.Profile;

namespace Application.Features.Categories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Command Mapleri
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, DeleteCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();


            //Queries Mapleri

            CreateMap<IPaginate<Category>, GetListResponse<GetAllCategoryDto>>().ReverseMap();
            CreateMap<Category, GetAllCategoryDto>()
                .ForMember(c => c.ParentCategoryName, dest => dest.MapFrom(c => c.ParentCategory.Name))
                .ReverseMap();

            CreateMap<Category, GetByIdCategoryDto>()
                .ForMember(x => x.ParentCategoryName, dest => dest.MapFrom(x => x.ParentCategory.Name))
                .ReverseMap();


        }
    }
}
