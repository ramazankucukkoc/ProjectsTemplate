namespace Application.Features.Addresss.Dtos
{
    public class GetByUserIdAddressDto
    {
        public int CityId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CityName { get; set; }
        public string Email { get; set; }
        public string AddressDetail { get; set; }
        public string AddressAbbreviation { get; set; }//Adres Kısaltması
        public string PostalCode { get; set; }
    }
}
