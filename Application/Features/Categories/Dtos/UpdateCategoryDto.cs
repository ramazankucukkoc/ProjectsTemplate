namespace Application.Features.Categories.Dtos
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //  public string Slug { get; set; }
        public int ParentId { get; set; }

    }
}
