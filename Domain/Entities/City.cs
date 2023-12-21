using Core.Domain.Entities;

namespace Domain.Entities
{
    public class City : Entity
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Address> Address { get; set; }
        public string Name { get; set; }

    }
}
