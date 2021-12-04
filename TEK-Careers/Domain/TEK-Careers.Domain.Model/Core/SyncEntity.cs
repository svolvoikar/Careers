namespace TEK_Careers.Domain.Model.Core
{
    public abstract class SyncEntity : DBAuditableEntity, ISyncEntity
    {
        public bool IsActive { get; set; }
    }
}
