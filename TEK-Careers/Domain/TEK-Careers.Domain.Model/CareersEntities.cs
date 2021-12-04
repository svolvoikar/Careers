using TEK_Careers.Domain.Model.Core;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;

namespace TEK_Careers.Domain.Model
{
    public partial class CareersEntities : DbContext
    {
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is SyncEntity
                    && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as SyncEntity;
                if (entity != null)
                {
                    var identityName = Thread.CurrentPrincipal.Identity.Name;
                    var now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.IsActive = true;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                       base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }

    }
}
