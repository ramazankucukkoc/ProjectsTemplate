using Application.Features.Baskets.Command.CreateBasket;
using Application.Features.Baskets.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Baskets.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            CreateMap<Basket, CreateBasketCommand>().ReverseMap();
            CreateMap<IPaginate<Basket>, GetListResponse<GetByBrandIdBasketDto>>().ReverseMap();
            CreateMap<Basket, GetByBrandIdBasketDto>()
                 .ForMember(b => b.BrandName, dest => dest.MapFrom(b => b.Brand.Name))
                .ForMember(b => b.ParentCategoryName, dest => dest.MapFrom(b => b.Product.Category.ParentCategory.Name))
                .ForMember(b => b.CategoryName, dest => dest.MapFrom(b => b.Product.Category.Name))
                .ForMember(b => b.ProductName, dest => dest.MapFrom(b => b.Product.Name))
                .ForMember(b => b.UserName, dest => dest.MapFrom(b => b.User.FirstName + " " + b.User.LastName))
                .ForMember(b => b.Email, dest => dest.MapFrom(b => b.User.Email))
                .ReverseMap();

            CreateMap<IPaginate<BasketListDto>, GetListResponse<BasketListDto>>().ReverseMap();


            CreateMap<Basket, DeleteBasketDto>()
                .ForMember(b => b.BrandName, dest => dest.MapFrom(b => b.Brand.Name))
               .ForMember(b => b.ProductName, dest => dest.MapFrom(b => b.Product.Name))
               .ForMember(b => b.UserName, dest => dest.MapFrom(b => b.User.FirstName + " " + b.User.LastName))
               .ForMember(b => b.Email, dest => dest.MapFrom(b => b.User.Email))
               .ReverseMap();
        }

    }
}
