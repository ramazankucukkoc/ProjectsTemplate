using Application.Features.Favorites.Dtos;
using Application.Features.Favorites.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Favorites.Command.UpdateFavorite
{
    public class UpdateFavoriteCommand:IRequest<UpdateFavoriteDto>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }

        public class UpdateFavoriteCommandHandler : IRequestHandler<UpdateFavoriteCommand, UpdateFavoriteDto>
        {
            private readonly IMapper _mapper;
            private readonly IFavoriteRepository _favoriteRepository;
            private readonly FavoriteBusinessRules _favoriteBusinessRules;

            public UpdateFavoriteCommandHandler(IMapper mapper, IFavoriteRepository favoriteRepository, FavoriteBusinessRules favoriteBusinessRules)
            {
                _mapper = mapper;
                _favoriteRepository = favoriteRepository;
                _favoriteBusinessRules = favoriteBusinessRules;
            }

            public async Task<UpdateFavoriteDto> Handle(UpdateFavoriteCommand request, CancellationToken cancellationToken)
            {
                await _favoriteBusinessRules.FavoriteIdShoulExistsWhenInserted(request.Id);
                Favorite? getByIdFavorite = await _favoriteRepository.GetAsync(f => f.Id == request.Id);
                _mapper.Map(request, getByIdFavorite);
                await _favoriteRepository.UpdateAsync(getByIdFavorite);
                UpdateFavoriteDto updateFavoriteDto =_mapper.Map<UpdateFavoriteDto>(getByIdFavorite);
                return updateFavoriteDto;
            }
        }
    }
}
