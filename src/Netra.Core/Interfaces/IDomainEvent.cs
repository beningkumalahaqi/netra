namespace Netra.Core.Interfaces;

public interface IDomainEvent
{
    DateTime OccurredAt { get; }
}
