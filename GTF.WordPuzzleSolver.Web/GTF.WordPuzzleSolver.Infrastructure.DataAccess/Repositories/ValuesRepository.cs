using GTF.WordPuzzleSolver.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GTF.WordPuzzleSolver.Infrastructure.DataAccess.Repositories
{
    public class ValuesRepository : BaseRepository
    {
        private readonly string _defaultFilePath;

        public ValuesRepository()
        {
            _defaultFilePath = $"{Environment.CurrentDirectory}\\Resources\\values.json";
        }

        public IList<Values> LoadData(string jsonPath = "")
        {
            if (string.IsNullOrEmpty(jsonPath))
            {
                jsonPath = _defaultFilePath;
            }

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
