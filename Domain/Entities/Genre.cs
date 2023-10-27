using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entitites;

namespace Domain.Entities
{
    public class Genre:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Person> People { get; set; }
    }
}