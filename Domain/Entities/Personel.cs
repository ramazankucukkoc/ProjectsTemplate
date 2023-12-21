using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Personel : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gorsel { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }
    }
}
