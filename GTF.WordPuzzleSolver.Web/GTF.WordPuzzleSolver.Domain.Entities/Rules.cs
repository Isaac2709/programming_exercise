﻿using System.Runtime.Serialization;

namespace GTF.WordPuzzleSolver.Domain.Entities
{
    [DataContract]
    public class Rules
    {
        private static int NextId = 0;

        public Rules()
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
        public string Source { get; set; }

        [DataMember]
        public string Replacement { get; set; }
    }
}
