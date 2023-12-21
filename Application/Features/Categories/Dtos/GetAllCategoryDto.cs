namespace Application.Features.Categories.Dtos
{
    public class GetAllCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string ParentCategoryName { get; set; }
    }
}
