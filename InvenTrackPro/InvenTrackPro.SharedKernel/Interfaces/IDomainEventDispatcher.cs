using InvenTrackPro.SharedKernel.Common.BaseEntities;

namespace InvenTrackPro.SharedKernel.Interfaces;
public interface IDomainEventDispatcher<TId>
{
    Task DispatchAndClearEvents(IEnumerable<BaseEntity<TId>> entitiesWithEvents);
}
