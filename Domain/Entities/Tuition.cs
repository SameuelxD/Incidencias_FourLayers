using Domain.Entities;

namespace Domain.Entitites
{
    public class Tuition:BaseEntity
    {
        public int IdPerson { get; set; }
        public int IdCourse { get; set; }
    }
}