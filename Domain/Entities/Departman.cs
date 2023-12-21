using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Departman : Entity
    {
        public string FullName { get; set; }//Departman adı
        public ICollection<Personel> Personels { get; set; }

    }
}
