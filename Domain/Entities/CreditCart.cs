using Core.Domain.Entities;

namespace Domain.Entities
{
    public class CreditCart : Entity
    {
        // public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string NameOnTheCard { get; set; }//Kart üzerindeki isim
        public string CardNumber { get; set; }//Kart Numarası
        public string CardCvv { get; set; }//Güvenlik Kodu
        public string ExpirationDate { get; set; }//Son kullanma tarihi
        public decimal MoneyInTheCard { get; set; }//Karttaki Para
    }
}
