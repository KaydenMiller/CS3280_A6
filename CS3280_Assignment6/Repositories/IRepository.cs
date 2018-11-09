using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //TEntity Get(int id);
        //IEnumerable<TEntity> GetAll();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //void Add(TEntity item);
        //void AddRange(IEnumerable<TEntity> items);

        //void Remove(TEntity item);
        //void RemoveRange(IEnumerable<TEntity> items);

        void Add(TEntity item);
        void Remove(TEntity item);
        TEntity FindByID(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAll();
    }
}
