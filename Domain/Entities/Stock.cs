using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Stock : Entity
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
