namespace Library.Domain.Core.Events;

/// <summary>
/// 
/// </summary>
public abstract record DomainEvent : IDomainEvent
{
    /// <summary>
    /// 
    /// </summary>
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        OccuredOn = DateTime.UtcNow;
    }

    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime OccuredOn { get; }
}
