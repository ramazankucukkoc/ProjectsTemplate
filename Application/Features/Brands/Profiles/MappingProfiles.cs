using Application.Features.Brands.Command.CreateBrand;
using Application.Features.Brands.Command.DeleteBrand;
using Application.Features.Brands.Command.UpdateBrand;
using Application.Features.Brands.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //-----------------Command-------------------------------
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
            CreateMap<Brand, DeleteBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();


            //------------------Quries--------------------------------
            CreateMap<Brand, BrandDto>().ReverseMap();

            CreateMap<Brand, BrandListDto>().ReverseMap();
            CreateMap<IPaginate<Brand>, GetListResponse<BrandListDto>>().ReverseMap();

        }

    }
}
