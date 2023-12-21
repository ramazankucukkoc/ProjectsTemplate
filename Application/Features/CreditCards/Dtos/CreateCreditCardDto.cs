using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CreditCards.Dtos
{
    public class CreateCreditCardDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NameOnTheCard { get; set; }//Kart üzerindeki isim
        public string CardNumber { get; set; }//Kart Numarası
        public string CardCvv { get; set; }//Güvenlik Kodu
        public string ExpirationDate { get; set; }//Son kullanma tarihi
        public decimal MoneyInTheCard { get; set; }//Karttaki Para
    }
}
