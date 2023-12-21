using Core.Application.DTOs;

namespace Application.Features.Categories.Dtos
{
    public class CreateCategoryDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}
