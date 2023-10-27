using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string ViaType { get; set; }
        public int Number { get; set; }
        public string Letter { get; set; }
        public string CardinalSuffix { get; set; }
        public int SecondaryRoadNumber { get; set; }
        public string SecondaryRoadLetter { get; set; }
        public string CardsSuffix { get; set; }
        public string IdPerson { get; set; }
    }
}