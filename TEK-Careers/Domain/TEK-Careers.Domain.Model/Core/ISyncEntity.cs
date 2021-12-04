using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEK_Careers.Domain.Model.Core
{
    public interface ISyncEntity
    {
        bool IsActive { get; set; }
    }
}
