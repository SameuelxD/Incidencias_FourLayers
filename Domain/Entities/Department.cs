using Domain.Entities;

namespace Domain.Entitites
{
    public class Department:BaseEntity
    {
        public string IdDepartment { get; set; }
        public string Name { get; set; }
        public string IdCountry { get; set; }
        public Country Countries { get; set; }
        public ICollection<City> Cities { get; set; }

    }
}