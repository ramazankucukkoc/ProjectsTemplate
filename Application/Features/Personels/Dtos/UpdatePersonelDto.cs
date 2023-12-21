namespace Application.Features.Personels.Dtos
{
    public class UpdatePersonelDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gorsel { get; set; }
        public int DepartmanId { get; set; }
    }
}
