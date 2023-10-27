using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class TuitionDto
    {
        public int Id { get; set; }
        public string IdPerson { get; set; }
        public int IdCourse { get; set; }
    }
}