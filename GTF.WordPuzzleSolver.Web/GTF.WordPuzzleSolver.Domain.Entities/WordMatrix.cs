﻿using System;
using System.Collections.Generic;

namespace GTF.WordPuzzleSolver.Domain.Entities
{
    public class WordMatrix
    {
        public IList<String> Cypher { get; set; }
        public IList<Rules> Rules { get; set; }
        public IList<String> Words { get; set; }
        public IList<Values> Values { get; set; }
    }
}
