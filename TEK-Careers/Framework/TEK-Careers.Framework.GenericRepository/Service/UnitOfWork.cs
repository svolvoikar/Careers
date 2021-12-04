using System;
using System.Data.Entity;


namespace TEK_Careers.Framework.GenericRepository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// DbContext object to access EF
        /// </summary>
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            //Save the Changes in DB with Default Settings
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources used by class
        /// </summary>
        /// <param name="disposing">will call dispose method if set to true.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
