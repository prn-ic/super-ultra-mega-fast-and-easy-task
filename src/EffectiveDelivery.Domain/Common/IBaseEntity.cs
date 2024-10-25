using MediatR;

namespace EffectiveDelivery.Domain.Common;

public interface IBaseEntity
{
    IReadOnlyCollection<INotification> DomainEvents { get; }
    void AddEvent(INotification notification);
    void ClearEvents();
}