using GTF.WordPuzzleSolver.Domain.Entities;
using System.Collections.Generic;

namespace GTF.WordPuzzleSolver.Infrastructure.DataAccess.Repositories
{
    public class RulesRepository : BaseRepository
    {
        public IList<Rules> LoadData(string jsonPath= "C:\\Users\\isaac\\source\\repos\\programming_exercise\\files\\json\\base.json")
        {
            Rules.ResetNextId(0);
            var rules = base.LoadData<Rules>(jsonPath);

            return rules;
        }
    }
}
