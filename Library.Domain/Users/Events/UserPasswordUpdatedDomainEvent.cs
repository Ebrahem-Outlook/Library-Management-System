using Library.Domain.Core.Events;

namespace Library.Domain.Users.Events
{
    /// <summary>
    /// Represents an event that is raised when a <see cref="User"/>'s password is updated.
    /// Inherits from <see cref="DomainEvent"/> to include event-related metadata.
    /// </summary>
    public sealed record UserPasswordUpdatedDomainEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPasswordUpdatedDomainEvent"/> class.
        /// </summary>
        /// <param name="user">The user whose password was updated.</param>
        public UserPasswordUpdatedDomainEvent(User User) : base()
        {
            this.User = User;
        }

        /// <summary>
        /// Gets the user whose password was updated.
        /// </summary>
        public User User { get; }
    }
}
