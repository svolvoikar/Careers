using TEK_Careers.Application.ServicePattern.Core;
using TEK_Careers.Domain.Model;

namespace TEK_Careers.Application.ServicePattern
{
    public interface IDepartmentService : ISyncEntityService<Department>
    {
        Department GetByName(string name);
    }
}
