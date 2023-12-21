using Core.Domain.Entities;
using Domain.Enums;

namespace Domain.Entities
{
    public class ProductBranch : Entity
    {
        public string Name { get; set; }
        public CitiesPlate Cities { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
