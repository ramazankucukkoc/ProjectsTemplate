using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Favorite : Entity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
