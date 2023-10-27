using Domain.Entities;

namespace Domain.Entitites
{
    public class Tuition:BaseEntity
    {
        public string IdPerson { get; set; }
        public int IdCourse { get; set; }
        public Person People { get; set; }
        public Course Courses { get; set; }
    }
}