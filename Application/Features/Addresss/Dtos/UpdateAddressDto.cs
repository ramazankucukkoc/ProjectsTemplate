namespace Application.Features.Addresss.Dtos
{
    public class UpdateAddressDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string AddressDetail { get; set; }
        public string AddressAbbreviation { get; set; }//Adres Kısaltması
        public string PostalCode { get; set; }
    }
}
