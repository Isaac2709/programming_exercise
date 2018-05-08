using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace GTF.WordPuzzleSolver.Infrastructure.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        public virtual IList<TRequest> LoadData<TRequest>(string jsonPath)
        {
            using (StreamReader r = new StreamReader(jsonPath))
            {
                string json = r.ReadToEnd();
                IList<TRequest> items = JsonConvert.DeserializeObject<IList<TRequest>>(json);                

                return items;
            }
        }
    }
}
