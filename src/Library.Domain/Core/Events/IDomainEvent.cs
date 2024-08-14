using MediatR;

namespace Library.Domain.Core.Events;

/// <summary>
/// 
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// 
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// 
    /// </summary>
    DateTime OccuredOn { get; }
}
