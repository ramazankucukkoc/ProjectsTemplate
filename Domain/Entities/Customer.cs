using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Customer : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public virtual CorporateCustomer? CorporateCustomer { get; set; }
        public virtual FindeksCreditRate? FindeksCreditRate { get; set; }
        public virtual IndividualCustomer? IndividualCustomer { get; set; }
        public ICollection<CustomerAddress> CustomerAddress { get; set; }
        public ICollection<Sale> Sales { get; set; }



    }
}
