using System.Collections.Generic;

namespace GTF.WordPuzzleSolver.Web.Models
{
    public class WordMatrixModel
    {
        public IList<IList<char>> Matrix { get; set; }

        public IList<string> Words { get; set; }
    }
}
