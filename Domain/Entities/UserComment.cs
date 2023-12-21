using Core.Domain.Entities;

namespace Domain.Entities
{
    public class UserComment : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Comment { get; set; }
    }
}
