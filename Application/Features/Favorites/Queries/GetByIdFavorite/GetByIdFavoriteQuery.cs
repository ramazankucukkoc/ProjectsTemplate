using Application.Features.Favorites.Dtos;
using Application.Features.Favorites.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Favorites.Queries.GetByIdFavorite
{
    public class GetByIdFavoriteQuery:IRequest<IPaginate<GetByIdFavoriteDto>>
    {
        public int ProductId { get; set; }

        public class GetByIdFavoriteQueryHandler : IRequestHandler<GetByIdFavoriteQuery, IPaginate<GetByIdFavoriteDto>>
        {
            private readonly IFavoriteRepository _favoriteRepository;
            private readonly FavoriteBusinessRules _favoriteBusinessRules;
            private readonly IMapper _mapper;


            public GetByIdFavoriteQueryHandler(IFavoriteRepository favoriteRepository,
                FavoriteBusinessRules favoriteBusinessRules,IMapper mapper)
            {
                _mapper = mapper;
                _favoriteRepository = favoriteRepository;
                _favoriteBusinessRules = favoriteBusinessRules;
            }

            public async Task<IPaginate<GetByIdFavoriteDto>> Handle(GetByIdFavoriteQuery request, CancellationToken cancellationToken)
            {
                await _favoriteBusinessRules.FavoriteIdShoulExistsWhenInserted(request.ProductId);
                IPaginate<GetByIdFavoriteDto> getAllFavorite = await _favoriteRepository.GetAllFavoriteAsync(request.ProductId);
                return getAllFavorite;

            }
        }
    }
}
