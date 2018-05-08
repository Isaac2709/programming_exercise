using System;
using System.Collections.Generic;

namespace GTF.WordPuzzleSolver.Infrastructure.DataAccess.Repositories
{
    public class WordsRepository : BaseRepository
    {
        private readonly string _defaultFilePath;

        public WordsRepository()
        {
            _defaultFilePath = $"{Environment.CurrentDirectory}\\Resources\\words.json";
        }

        public IList<string> LoadData(string jsonPath = "")
        {
            if (string.IsNullOrEmpty(jsonPath))
            {
                jsonPath = _defaultFilePath;
            }

            var words = base.LoadData<string>(jsonPath);

            return words;
        }
    }
}
