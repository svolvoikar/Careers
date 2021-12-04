using System;

namespace TEK_Careers.Framework.GenericRepository
{
    public interface IEntity<Tid> where Tid : IComparable
    {
        Tid ID { get; set; }
    }
}
