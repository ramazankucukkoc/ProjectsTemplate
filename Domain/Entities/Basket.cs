using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Basket : Entity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Brand Brand { get; set; }
        public User User { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }
        // public decimal TotalPrice { get; set; }

    }
}
