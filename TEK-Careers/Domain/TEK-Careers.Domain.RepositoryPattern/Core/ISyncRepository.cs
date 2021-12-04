using TEK_Careers.Framework.GenericRepository;
using System.Linq;

namespace TEK_Careers.Domain.RepositoryPattern.Core
{
    public interface ISyncRepository<T> : IGenericRepository<T>
         where T : BaseEntity
    {
        IQueryable<T> GetAllActiveRecords();
        T GetByID(long id);
    }
}
