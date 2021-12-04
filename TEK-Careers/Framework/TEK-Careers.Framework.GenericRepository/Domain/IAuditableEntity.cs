using System;

namespace TEK_Careers.Framework.GenericRepository
{
    public interface IAuditableEntity<Tid> where Tid : struct, IComparable
    {
        DateTime UpdatedDate { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
