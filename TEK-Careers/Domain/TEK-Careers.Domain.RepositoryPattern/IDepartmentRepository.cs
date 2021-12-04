using TEK_Careers.Domain.Model;
using TEK_Careers.Domain.RepositoryPattern.Core;

namespace TEK_Careers.Domain.RepositoryPattern
{
    public interface IDepartmentRepository : ISyncRepository<Department>
    {
    }
}
