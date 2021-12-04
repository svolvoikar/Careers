using System;

namespace TEK_Careers.Domain.Model.Core
{
    public interface IDBAuditableEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
