using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Sale : Entity
    {
        public int Quantity { get; set; }//Adet
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }

    }
}
