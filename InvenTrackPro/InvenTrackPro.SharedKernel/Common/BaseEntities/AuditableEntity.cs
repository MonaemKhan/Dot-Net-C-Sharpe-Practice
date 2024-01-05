using InvenTrackPro.SharedKernel.Interfaces;

namespace InvenTrackPro.SharedKernel.Common.BaseEntities;

public abstract class AuditableEntity<TId> : BaseEntity<TId>, IAggregateRoot
{
    public AuditableEntity()
    {
        CreatedDate = DateTimeOffset.UtcNow;
        CreatedBy = 1;
        IsDelete = false;
        IsActive = true;
    }

    public DateTimeOffset CreatedDate { get; set; }
    public long CreatedBy { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
    public long? ModifiedBy { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
}

// abstract class
public abstract class AuditableEntity : AuditableEntity<long>
{
}
