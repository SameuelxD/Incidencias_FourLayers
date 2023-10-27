using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Capacity { get; set; }
    }
}