using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Favorites.Dtos
{
    public class GetByIdFavoriteDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
    }
}
