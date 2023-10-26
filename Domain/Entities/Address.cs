using Domain.Entities;

namespace Domain.Entitites
{
    public class Address:BaseEntity
    {
        public string ViaType { get; set; }
        public int Number { get; set; }
        public string Letter { get; set; }
        public string CardinalSuffix { get; set; }
        public int SecondaryRoadNumber { get; set; }
        public string SecondaryRoadLetter { get; set; }
        public string CardsSuffix { get; set; }
        public int IdPerson { get; set; }
        
    }
}