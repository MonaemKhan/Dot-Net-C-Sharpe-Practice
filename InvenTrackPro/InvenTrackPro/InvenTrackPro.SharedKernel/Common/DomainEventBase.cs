using MediatR;

namespace InvenTrackPro.SharedKernel.Common;

public abstract class DomainEventBase : INotification
{
    public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
    //date time variable
}