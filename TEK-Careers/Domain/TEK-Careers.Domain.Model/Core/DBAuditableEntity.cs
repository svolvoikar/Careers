using TEK_Careers.Framework.GenericRepository;
using System;

namespace TEK_Careers.Domain.Model.Core
{
    public abstract class DBAuditableEntity : AuditableEntity<long>, IDBAuditableEntity
    {
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
    }
}
