using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Country : Entity
    {
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
