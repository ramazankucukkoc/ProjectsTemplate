using Application.Features.Favorites.Command.CreateFavorite;
using Application.Features.Favorites.Command.DeleteFavorite;
using Application.Features.Favorites.Command.UpdateFavorite;
using Application.Features.Favorites.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Favorites.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateFavoriteCommand, CreateFavoriteDto>().ReverseMap();
            CreateMap<Favorite, CreateFavoriteDto>().ReverseMap();
            CreateMap<DeleteFavoriteCommand, DeleteFavoriteDto>().ReverseMap();
            CreateMap<UpdateFavoriteDto, UpdateFavoriteCommand>().ReverseMap();
        }

    }
}
