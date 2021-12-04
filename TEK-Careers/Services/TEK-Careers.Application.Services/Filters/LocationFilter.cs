using System.Linq;
using TEK_Careers.Domain.Model;

namespace TEK_Careers.Application.Services.Filters
{
    public static class LocationFilter
    {
        public static IQueryable<Location> WithTitle(this IQueryable<Location> qry, string name)
        {
            return qry.Where(u => u.Title.ToLower() == name.ToLower());
        }

        public static IQueryable<Location> WithActive(this IQueryable<Location> qry)
        {
            return qry.Where(c => c.IsActive == true);
        }
    }
}
