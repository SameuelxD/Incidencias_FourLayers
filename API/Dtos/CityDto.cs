using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string IdCity { get; set; }
        public string Name { get; set; }
        public string IdDepartment { get; set; }
    }
}