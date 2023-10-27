using Domain.Entities;

namespace Domain.Entitites
{
    public class TypePerson:BaseEntity
    {
        public string Description { get; set; } 
        public ICollection<Person> People { get; set; }
    }
}