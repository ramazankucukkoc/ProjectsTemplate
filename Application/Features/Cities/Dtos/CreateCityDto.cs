namespace Application.Features.Cities.Dtos
{
    public class CreateCityDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
