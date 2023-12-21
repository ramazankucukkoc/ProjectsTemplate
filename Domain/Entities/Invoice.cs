using Core.Domain.Entities;

namespace Domain.Entities
{
    //Fatura
    public class Invoice : Entity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public double TotalSum { get; set; }
        public string No { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


    }
}
