using System.Collections.Generic;

namespace GTF.WordPuzzleSolver.Infrastructure.DataAccess.Repositories
{
    public class WordsRepository : BaseRepository
    {
        public IList<string> LoadData(string jsonPath = "C:\\Users\\isaac\\source\\repos\\programming_exercise\\files\\json\\words.json")
        {
            var words = base.LoadData<string>(jsonPath);

            return words;
        }
    }
}
