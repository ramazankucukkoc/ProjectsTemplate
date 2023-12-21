using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Brand : Entity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Basket> Baskets { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }
}
