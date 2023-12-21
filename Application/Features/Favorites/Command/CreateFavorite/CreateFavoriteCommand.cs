using Application.Features.Favorites.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Favorites.Command.CreateFavorite
{
    public class CreateFavoriteCommand : IRequest<CreateFavoriteDto>
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }

        public class CreateFavoriteCommandHandler : IRequestHandler<CreateFavoriteCommand, CreateFavoriteDto>
        {
            private readonly IFavoriteRepository _favoriteRepository;
            private readonly IMapper _mapper;

            public CreateFavoriteCommandHandler(IFavoriteRepository favoriteRepository, IMapper mapper)
            {
                _favoriteRepository = favoriteRepository;
                _mapper = mapper;
            }

            public async Task<CreateFavoriteDto> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
            {
                Favorite mappedFavorite = _mapper.Map<Favorite>(request);
                Favorite createdFavorite = await _favoriteRepository.AddAsync(mappedFavorite);
                CreateFavoriteDto createFavoriteDto = _mapper.Map<CreateFavoriteDto>(createdFavorite);
                return createFavoriteDto;
            }
        }
    }
}
