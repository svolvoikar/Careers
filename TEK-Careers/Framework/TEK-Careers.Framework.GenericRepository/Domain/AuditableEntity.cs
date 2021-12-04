using System;
using System.ComponentModel.DataAnnotations;

namespace TEK_Careers.Framework.GenericRepository
{
    public abstract class AuditableEntity<Tid> : Entity<Tid>, IAuditableEntity<Tid>
              where Tid : struct, IComparable
    {
        [ScaffoldColumn(false)]
        public DateTime UpdatedDate
        {
            get;
            set;
        }

        [ScaffoldColumn(false)]
        public DateTime CreatedDate
        {
            get;
            set;
        }
    }
}
