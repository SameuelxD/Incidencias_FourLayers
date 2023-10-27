using Domain.Entities;

namespace Domain.Entitites
{
    public class Person:BaseEntity
    {
        public string IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int IdGenre { get; set; }
        public string IdCity { get; set; }
        public int IdTypePerson { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public Genre Genders { get; set; } 
        public City Cities { get; set; }
        public TypePerson TypePeople { get; set; }
        public ICollection<Tuition> Tuitions { get; set; }
        public ICollection<TrainerCourse> TrainerCourses { get; set; }
    }
}