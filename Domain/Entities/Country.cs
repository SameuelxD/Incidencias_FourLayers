using Domain.Entities;

namespace Domain.Entitites
{
    public class Country:BaseEntity
    {
        public string IdCountry { get; set; }
        public string Name { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}