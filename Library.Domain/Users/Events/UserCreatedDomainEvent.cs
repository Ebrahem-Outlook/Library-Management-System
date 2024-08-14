using Library.Domain.Core.Events;

namespace Library.Domain.Users.Events
{
    /// <summary>
    /// Represents an event that is raised when a new <see cref="User"/> is created.
    /// Inherits from <see cref="DomainEvent"/> to include event-related metadata.
    /// </summary>
    public sealed record UserCreatedDomainEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserCreatedDomainEvent"/> class.
        /// </summary>
        /// <param name="user">The user that was created.</param>
        public UserCreatedDomainEvent(User User) : base()
        {
            this.User = User;
        }

        /// <summary>
        /// Gets the user that was created.
        /// </summary>
        public User User { get; }
    }
}
