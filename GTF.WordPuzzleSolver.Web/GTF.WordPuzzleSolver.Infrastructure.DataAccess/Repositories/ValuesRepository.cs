using GTF.WordPuzzleSolver.Domain.Entities;
using System.Collections.Generic;

namespace GTF.WordPuzzleSolver.Infrastructure.DataAccess.Repositories
{
    public class ValuesRepository : BaseRepository
    {
        public IList<Values> LoadData(string jsonPath = "C:\\Users\\isaac\\source\\repos\\programming_exercise\\files\\json\\values.json")
        {
            ValueRule.ResetNextId(0);
            Values.ResetNextId(0);

            var valueRules = base.LoadData<List<ValueRule>>(jsonPath);
            var values = new List<Values>();

            foreach (var valueRule in valueRules)
            {
                var value = new Values()
                {
                    ValueRules = valueRule
                };
                values.Add(value);
            }

            return values;
        }
    }
}
