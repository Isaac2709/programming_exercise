using GTF.WordPuzzleSolver.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GTF.WordPuzzleSolver.Infrastructure.DataAccess.Repositories
{
    public class RulesRepository : BaseRepository
    {
        private readonly string _defaultFilePath;

        public RulesRepository()
        {
            _defaultFilePath = $"{Environment.CurrentDirectory}\\Resources\\base.json";
        }

        public IList<Rules> LoadData(string jsonPath = "")
        {
            if (string.IsNullOrEmpty(jsonPath))
            {
                jsonPath = _defaultFilePath;
            }
            Rules.ResetNextId(0);
            var rules = base.LoadData<Rules>(jsonPath);

            return rules;
        }
    }
}
