﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Repositories
{
    interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        T FindByID(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll();
    }
}
