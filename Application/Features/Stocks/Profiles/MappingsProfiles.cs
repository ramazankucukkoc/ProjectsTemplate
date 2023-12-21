using Application.Features.Stocks.Command.CreateStock;
using Application.Features.Stocks.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Stocks.Profiles
{
    public class MappingsProfiles : Profile
    {
        public MappingsProfiles()
        {
            CreateMap<Stock, CreateStockDto>().ReverseMap();
            CreateMap<Stock, CreateStockCommand>().ReverseMap();
        }
    }
}
