using System.Runtime.Serialization;

namespace GTF.WordPuzzleSolver.Domain.Entities
{
    [DataContract]
    public class Rules
    {
        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public string Replacement { get; set; }
    }
}
