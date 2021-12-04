using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TEK_Careers.Framework.GenericRepository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
