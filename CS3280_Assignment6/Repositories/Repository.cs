using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Repositories
{
    public abstract class Repository<TEntity> where TEntity : new()
    {
        protected AdoNetContext Context { get; private set; }

        public Repository(AdoNetContext context)
        {
           Context = context;
        }

        protected IEnumerable<TEntity> ToList(OleDbCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                List<TEntity> items = new List<TEntity>();
                while (reader.Read())
                {
                    var item = new TEntity();
                    Map(reader, item);
                    items.Add(item);
                }
                return items;
            }
        }

        protected abstract void Map(IDataRecord record, TEntity entity);
    }
}
