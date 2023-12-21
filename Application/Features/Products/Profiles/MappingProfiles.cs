using Application.Features.Products.Command;
using Application.Features.Products.Dtos;
using Core.Persistence.Paging;
using Domain.Entities;
using Profile = AutoMapper.Profile;

namespace Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //----------Command And Dtos------------------
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>()
                .ForMember(x => x.CategoryName, dest => dest.MapFrom(x => x.Category.Name))
                .ReverseMap();

            //-----------Queries*---------------------
            CreateMap<IPaginate<Product>, GetListResponse<GetAllProductDto>>()
                .ReverseMap();
            //CreateMap<Product, GetAllProductDto>()
            //    .ForMember(p => p.CategoryName, opt => opt.MapFrom(p => p.Category.Name))
            //    .ForMember(p => p.ParentCategoryName, opt => opt.MapFrom(p => p.Category.ParentCategory.Name));

            CreateMap<Product, GetAllProductDto>()
                .ForMember(x => x.CategoryName, dest => dest.MapFrom(x => x.Category.Name))
                .ForMember(x => x.ParentCategoryName, dest => dest.MapFrom(x => x.Category.ParentCategory.Name))
                .ReverseMap();

            CreateMap<IPaginate<Product>, GetListResponse<GetByCategoryIdDto>>()
               .ReverseMap();
            CreateMap<Product, GetByCategoryIdDto>()
                .ForMember(p => p.CategoryName, dest => dest.MapFrom(p => p.Category.Name))
                .ReverseMap();
        }
    }
}
