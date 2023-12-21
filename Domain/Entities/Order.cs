using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Order : Entity
    {
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public int UserId { get; set; }
        public decimal SubTotal { get; set; }//Ara Toplam
        public double DisCount { get; set; }//Indirim
        public double Tax { get; set; } //Vergi
        public decimal Total { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsShippingDifferent { get; set; }//default false Nakliye Farklı mı?
        public DateTime CanceledDate { get; set; }//Iptal Tarihi.
        public DateTime DeliveredDate { get; set; }//Teslim Tarihi
    }
}
