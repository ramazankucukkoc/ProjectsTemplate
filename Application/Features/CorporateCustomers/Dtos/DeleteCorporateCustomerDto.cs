namespace Application.Features.CorporateCustomers.Dtos
{
    public class DeleteCorporateCustomerDto
    {
        public int CustomerId { get; set; }
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; }


    }
}
