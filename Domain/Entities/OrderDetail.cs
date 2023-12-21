using Core.Domain.Entities;

namespace Domain.Entities
{
    public class OrderDetail : Entity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public decimal SalePrice { get; set; }
        public int Count { get; set; }

    }
}
