using Core.Domain.Entities;

namespace Domain.Entities
{
    public class CustomerAddress : Entity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
