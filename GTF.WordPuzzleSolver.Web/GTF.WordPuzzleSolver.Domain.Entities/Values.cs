using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GTF.WordPuzzleSolver.Domain.Entities
{
    [DataContract]
    public class Values
    {
        private static int NextId = 0;

        public Values()
        {
            Id = NextId++;
        }

        public static void ResetNextId(int startId)
        {
            NextId = startId;
        }

        [DataMember]
        public int Id { get; private set; }

        [DataMember]        
        public IList<ValueRule> ValueRules { get; set; }
    }
}
