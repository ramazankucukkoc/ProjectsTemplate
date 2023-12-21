namespace Application.Features.Categories.Dtos
{
    public class DeleteCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }

    }
}
