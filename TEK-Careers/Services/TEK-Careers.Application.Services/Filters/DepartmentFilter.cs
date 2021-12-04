using System.Linq;
using TEK_Careers.Domain.Model;

namespace TEK_Careers.Application.Services.Filters
{
    public static class DepartmentFilter
    {
        public static IQueryable<Department> WithTitle(this IQueryable<Department> qry, string name)
        {
            return qry.Where(u => u.Title.ToLower() == name.ToLower());
        }

        public static IQueryable<Department> WithActive(this IQueryable<Department> qry)
        {
            return qry.Where(c => c.IsActive == true);
        }
    }
}
