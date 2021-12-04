using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEK_Careers.Framework.GenericRepository
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>Returns the count of objects in an Added,Modified, or Deleted state</returns>
        int Commit();
    }
}
