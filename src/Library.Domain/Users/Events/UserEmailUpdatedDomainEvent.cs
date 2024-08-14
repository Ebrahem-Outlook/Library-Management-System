using Library.Domain.Core.Events;

namespace Library.Domain.Users.Events
{
    /// <summary>
    /// Represents an event that is raised when a <see cref="User"/>'s email address is updated.
    /// Inherits from <see cref="DomainEvent"/> to include event-related metadata.
    /// </summary>
    public sealed record UserEmailUpdatedDomainEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserEmailUpdatedDomainEvent"/> class.
        /// </summary>
        /// <param name="user">The user whose email address was updated.</param>
        public UserEmailUpdatedDomainEvent(User User) : base()
        {
            this.User = User;
        }

        /// <summary>
        /// Gets the user whose email address was updated.
        /// </summary>
        public User User { get; }
    }
}
