using Library.Domain.Core.Events;

namespace Library.Domain.Users.Events
{
    /// <summary>
    /// Represents an event that is raised when a <see cref="User"/> is updated.
    /// Inherits from <see cref="DomainEvent"/> to include event-related metadata.
    /// </summary>
    public sealed record UserUpdatedDomainEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserUpdatedDomainEvent"/> class.
        /// </summary>
        /// <param name="user">The user that was updated.</param>
        public UserUpdatedDomainEvent(User User) : base()
        {
            this.User = User;
        }

        /// <summary>
        /// Gets the user that was updated.
        /// </summary>
        public User User { get; }
    }
}
