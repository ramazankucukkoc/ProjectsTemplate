using Core.Domain.Entities;

namespace Domain.Entities
{
    //Kurumsal Müşteri Şirketi Olan Müşteri diyebiliriz.
    public class CorporateCustomer : Entity
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; }//Vergi No

        public virtual Customer Customer { get; set; }

        public CorporateCustomer()
        {
        }

        public CorporateCustomer(int id, int customerId, string companyName, string taxNo) : base(id)
        {
            CustomerId = customerId;
            CompanyName = companyName;
            TaxNo = taxNo;
        }
    }
}
