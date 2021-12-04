using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEK_Careers.Framework.GenericRepository
{
    public class Entity<Tid> : BaseEntity, IEntity<Tid>
          where Tid : System.IComparable
    {
        public Tid ID { get; set; }
    }
}
