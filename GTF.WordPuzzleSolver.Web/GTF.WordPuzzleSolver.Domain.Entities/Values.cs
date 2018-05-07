using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GTF.WordPuzzleSolver.Domain.Entities
{
    [DataContract]
    public class Values
    {        
        [DataMember]        
        public IList<ValueRule> ValueRules { get; set; }
    }
}
