using Domain.Entities;

namespace Domain.Entitites
{
    public class Course:BaseEntity
    {
        public string CourseName { get; set; }
        public int Capacity { get; set; }
        public ICollection<Tuition> Tuitions { get; set; } 
        public ICollection<TrainerCourse> TrainerCourses { get; set; }
        
    }
}