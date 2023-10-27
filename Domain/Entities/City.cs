using Domain.Entities;

namespace Domain.Entitites
{
    public class City:BaseEntity
    {
        public string IdCity { get; set; }
        public string Name { get; set; }
        public string IdDepartment { get; set; }
        public ICollection<Person> People { get; set; }
        public Department Departments { get; set; }
    }
}