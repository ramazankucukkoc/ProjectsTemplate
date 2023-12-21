namespace Application.Features.Cities.Dtos
{
    public class DeleteCityDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
