namespace Application.Features.IndividualCustomers.Dtos
{
    public class CreateIndividualCustomerDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }//Ulusal kimlik Uyruk diyebilriz.
    }
}
