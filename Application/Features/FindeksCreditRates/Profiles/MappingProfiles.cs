using Application.Features.FindeksCreditRates.Command.CreateFindeksCreditRate;
using Application.Features.FindeksCreditRates.Command.DeleteFindeksCreditRate;
using Application.Features.FindeksCreditRates.Command.UpdateFindeksCreditRate;
using Application.Features.FindeksCreditRates.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.FindeksCreditRates.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<FindeksCreditRate, CreateFindeksCreditRateCommand>().ReverseMap();
            CreateMap<FindeksCreditRate, DeleteFindeksCreditRateCommand>().ReverseMap();
            CreateMap<FindeksCreditRate, UpdateFindeksCreditRateCommand>().ReverseMap();


            CreateMap<FindeksCreditRate, UpdateFindeksCreditRateDto>().ReverseMap();
            CreateMap<FindeksCreditRate, CreateFindeksCreditRateDto>().ReverseMap();
            CreateMap<FindeksCreditRate, DeleteFindeksCreditRateDto>().ReverseMap();
            CreateMap<FindeksCreditRate, FindeksCreditRateDto>().ReverseMap();

            CreateMap<IPaginate<FindeksCreditRate>, GetListResponse<FindeksCreditRateDto>>().ReverseMap();

        }
    }
}
