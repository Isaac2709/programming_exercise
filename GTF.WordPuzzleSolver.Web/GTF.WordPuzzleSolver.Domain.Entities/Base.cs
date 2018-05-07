using System.Runtime.Serialization;

namespace GTF.WordPuzzleSolver.Domain.Entities
{
    [DataContract]
    public class Base
    {        
        [DataMember]
        string Source { get; set; }

        [DataMember]
        string Replacement { get; set; }
    }
}
