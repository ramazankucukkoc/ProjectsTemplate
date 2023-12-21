namespace Core.Domain.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Active { get; set; } = true;
        public Entity()
        {

        }
        public Entity(int id) : this()
        {
            Id = id;
        }

    }
}
