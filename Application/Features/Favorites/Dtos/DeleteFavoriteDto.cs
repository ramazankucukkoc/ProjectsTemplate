﻿namespace Application.Features.Favorites.Dtos
{
    public class DeleteFavoriteDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }
    }
}
