namespace Application.Features.Categories.Dtos
{
    public class GetByIdCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string ParentCategoryName { get; set; }
    }
}
