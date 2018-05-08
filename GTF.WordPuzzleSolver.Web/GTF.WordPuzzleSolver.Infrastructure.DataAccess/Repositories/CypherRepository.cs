using System.Collections.Generic;

namespace GTF.WordPuzzleSolver.Infrastructure.DataAccess.Repositories
{
    public class CypherRepository : BaseRepository
    {
        public IList<string> LoadData(string jsonPath = "C:\\Users\\isaac\\source\\repos\\programming_exercise\\files\\json\\cypher.json")
        {
            var cypher = base.LoadData<string>(jsonPath);

            return cypher;
        }
    }
}
