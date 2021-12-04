using TEK_Careers.Domain.Model.Core;
using TEK_Careers.Framework.GenericRepository;
using System.Linq;

namespace TEK_Careers.Application.ServicePattern.Core
{
    public interface ISyncEntityService<T> : IEntityService<T> where T : SyncEntity
    {
        IQueryable<T> GetAllActiveRecords();
        T GetByID(long id);
        void InActivateRecord(T entity);
    }
}
