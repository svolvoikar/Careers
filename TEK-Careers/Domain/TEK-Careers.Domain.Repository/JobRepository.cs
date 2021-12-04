using System.Data.Entity;
using TEK_Careers.Domain.Model;
using TEK_Careers.Domain.Repository.Core;
using TEK_Careers.Domain.RepositoryPattern;

namespace TEK_Careers.Domain.Repository
{
    public class JobRepository : SyncRepository<Job>, IJobRepository
    {
        public JobRepository(DbContext context) : base(context)
        {
        }
    }
}
