using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TEK_Careers.Framework.GenericRepository
{

    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        private readonly IDbSet<T> dbset;

        protected GenericRepository(DbContext context)
        {
            _entities = context;
            dbset = context.Set<T>();
        }

        protected DbContext _entities { get; set; }

        protected IDbSet<T> Dbset
        {
            get
            {
                return dbset;
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            return Dbset;
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = Dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return Dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return Dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
