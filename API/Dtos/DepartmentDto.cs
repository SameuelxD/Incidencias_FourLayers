using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string IdDepartment { get; set; }
        public string Name { get; set; }
        public string IdCountry { get; set; }
    }
}