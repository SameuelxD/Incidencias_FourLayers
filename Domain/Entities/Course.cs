using Domain.Entities;

namespace Domain.Entitites
{
    public class Course:BaseEntity
    {
        public string CourseName { get; set; }
        public int Capacity { get; set; }
        
    }
}