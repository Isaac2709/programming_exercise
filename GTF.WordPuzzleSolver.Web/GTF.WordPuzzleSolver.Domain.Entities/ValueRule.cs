using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace GTF.WordPuzzleSolver.Domain.Entities
{
    [DataContract]    
    public class ValueRule
    {
        private static int NextId = 0;

        public ValueRule()
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
        public int Order { get; set; }

        [DataMember]
        public int Rule { get; set; }

        [DataMember]
        public bool IsTermination { get; set; }
    }
}
