using Core.Domain.Entities;

namespace Domain.Entities
{
    public class ParentCategory : Entity
    {
        public ICollection<Category> Categories { get; set; }
        public string Name { get; set; }

    }
}
