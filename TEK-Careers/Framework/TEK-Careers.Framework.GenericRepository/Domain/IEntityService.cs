using System.Collections.Generic;
using System.Linq;

namespace TEK_Careers.Framework.GenericRepository
{
    public interface IEntityService<T> : IService
        where T : BaseEntity
    {
        void Create(T entity);
        void Create(List<T> entityList);
        void Update(T entity);
        void Update(List<T> entityList);
        void Delete(T entity);
        IQueryable<T> GetAll();

    }
}
