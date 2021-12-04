using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEK_Careers.Domain.Model;
using TEK_Careers.Domain.Repository.Core;
using TEK_Careers.Domain.RepositoryPattern;

namespace TEK_Careers.Domain.Repository
{
    public class DepartmentRepository : SyncRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context) : base(context)
        {
        }
    }
}
