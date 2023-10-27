using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int IdGenre { get; set; }
        public string IdCity { get; set; }
        public int IdTypePerson { get; set; }
    }
}