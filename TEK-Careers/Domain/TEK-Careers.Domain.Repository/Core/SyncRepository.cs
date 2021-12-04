using TEK_Careers.Domain.Model.Core;
using TEK_Careers.Domain.RepositoryPattern.Core;
using TEK_Careers.Framework.GenericRepository;
using System.Data.Entity;
using System.Linq;

namespace TEK_Careers.Domain.Repository.Core
{
    public abstract class SyncRepository<T> : GenericRepository<T>, ISyncRepository<T>
       where T : SyncEntity
    {
        public SyncRepository(DbContext context)
            : base(context)
        {
        }

        public virtual IQueryable<T> GetAllActiveRecords()
        {
            return Dbset.Where(x => x.IsActive == true);
        }

        public virtual T GetByID(long id)
        {
            return Dbset.Where(x => x.ID == id).FirstOrDefault();
        }
    }
}
