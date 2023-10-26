using Domain.Entities;

namespace Domain.Entitites
{
    public class Department:BaseEntity
    {
        public string IdDepartment { get; set; }
        public string Name { get; set; }
        public int IdCountry { get; set; }

    }
}