using System;
using System.Collections.Generic;

namespace GTF.WordPuzzleSolver.Infrastructure.DataAccess.Repositories
{
    public class CypherRepository : BaseRepository
    {
        private readonly string _defaultFilePath;

        public CypherRepository()
        {
            _defaultFilePath = $"{Environment.CurrentDirectory}\\Resources\\cypher.json";
        }

        public IList<string> LoadData(string jsonPath = "")
        {
            if (string.IsNullOrEmpty(jsonPath))
            {
                jsonPath = _defaultFilePath;
            }
            var cypher = base.LoadData<string>(jsonPath);

            return cypher;
        }
    }
}
