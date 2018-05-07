using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace GTF.WordPuzzleSolver.Domain.Entities
{
    [DataContract]    
    public class ValueRule
    {
        [DataMember]
        int Order { get; set; }

        [DataMember]
        int Rule { get; set; }

        [DataMember]
        bool IsTermination { get; set; }
    }
}
