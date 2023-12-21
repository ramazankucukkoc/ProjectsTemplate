using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public ParentCategory ParentCategory { get; set; }
        public int ParentId { get; set; }
        public List<Product> Products { get; set; }



    }
}
