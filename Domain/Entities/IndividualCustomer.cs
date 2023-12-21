using Core.Domain.Entities;

namespace Domain.Entities
{
    //Bireysel Müşteri Sadece Kendisi olan diyebiliriz.
    public class IndividualCustomer : Entity
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }//Ulusal kimlik Uyruk diyebilriz.
        public virtual Customer Customer { get; set; }
    }
}
