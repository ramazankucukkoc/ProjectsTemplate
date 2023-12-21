using Application.Features.Orders.Command;
using Domain.Entities;
using Profile = AutoMapper.Profile;

namespace Application.Features.Orders.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, CreateOrderCommand>().ReverseMap();


        }
    }
}
