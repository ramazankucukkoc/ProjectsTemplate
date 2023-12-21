using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Address : Entity
    {
        public ICollection<CustomerAddress> CustomerAddress { get; set; }
        public ICollection<Order> Orders { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string AddressDetail { get; set; }
        public string AddressAbbreviation { get; set; }//Adres Kısaltması
        public string PostalCode { get; set; }
    }
}
