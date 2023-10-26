using Domain.Entities;

namespace Domain.Entitites
{
    public class Person:BaseEntity
    {
        public string IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int IdGenre { get; set; }
        public int IdCity { get; set; }
        public int IdTypePerson { get; set; }
    }
}