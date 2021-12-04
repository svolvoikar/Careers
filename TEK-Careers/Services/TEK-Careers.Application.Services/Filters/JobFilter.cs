using System.Linq;
using TEK_Careers.Domain.Model;

namespace TEK_Careers.Application.Services.Filters
{
    public static class JobFilter
    {
        public static IQueryable<Job> WithTitle(this IQueryable<Job> qry, string name)
        {
            return qry.Where(u => u.Title.ToLower() == name.ToLower());
        }

        public static IQueryable<Job> WithActive(this IQueryable<Job> qry)
        {
            return qry.Where(c => c.IsActive == true);
        }
    }
}
