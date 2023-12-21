using Application.Features.Favorites.Dtos;
using Application.Features.Favorites.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Favorites.Command.DeleteFavorite
{
    public class DeleteFavoriteCommand:IRequest<DeleteFavoriteDto>
    {
        public int Id { get; set; }

        public class DeleteFavoriteCommandHandler : IRequestHandler<DeleteFavoriteCommand, DeleteFavoriteDto>
        {
            private readonly IFavoriteRepository _favoriteRepository;
            private readonly IMapper _mapper;
            private readonly FavoriteBusinessRules _favoriteBusinessRules;

            public DeleteFavoriteCommandHandler(IFavoriteRepository favoriteRepository,
                IMapper mapper, FavoriteBusinessRules favoriteBusinessRules)
            {
                _favoriteRepository = favoriteRepository;
                _mapper = mapper;
                _favoriteBusinessRules = favoriteBusinessRules;
            }

            public async Task<DeleteFavoriteDto> Handle(DeleteFavoriteCommand request, CancellationToken cancellationToken)
            {
                await _favoriteBusinessRules.FavoriteIdShoulExistsWhenInserted(request.Id);
                Favorite? getByIdFavorite = await _favoriteRepository.GetAsync(f => f.Id == request.Id);
                Favorite deletedFavorite = await _favoriteRepository.DeleteAsync(getByIdFavorite);
                DeleteFavoriteDto deleteFavoriteDto = _mapper.Map<DeleteFavoriteDto>(deletedFavorite);
                return deleteFavoriteDto;
            }
        }
    }
}
