using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Favorites.Rules
{
    public class FavoriteBusinessRules
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteBusinessRules(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task FavoriteIdShoulExistsWhenInserted(int id)
        {
            Favorite? result = await _favoriteRepository.GetAsync(f => f.Id == id);
            if (result == null) throw new BusinessException("Favorilerde silinecek veri yok");
        }
    }
}
