using Domain.Entities;

namespace Domain.Entitites
{
    public class City:BaseEntity
    {
        public string IdCity { get; set; }
        public string Name { get; set; }
        public int IdDepartment { get; set; }
    }
}