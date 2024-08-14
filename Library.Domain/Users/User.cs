using Library.Domain.Core.BaseType;
using Library.Domain.Users.Events;

namespace Library.Domain.Users
{
    /// <summary>
    /// Represents a user in the system, with properties for first name, last name, email, and password hash.
    /// Inherits from <see cref="AggregateRoot"/> to serve as an aggregate root in the domain model.
    /// </summary>
    public sealed class User : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class with the specified values.
        /// This constructor is private to enforce the use of the <see cref="Create"/> method for instantiation.
        /// </summary>
        /// <param name="firstName">The user's first name.</param>
        /// <param name="lastName">The user's last name.</param>
        /// <param name="email">The user's email address.</param>
        /// <param name="passwordHash">The hashed password for the user.</param>
        private User(string firstName, string lastName, string email, string passwordHash)
            : base(Guid.NewGuid())
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class for ORM purposes.
        /// This constructor is private to prevent direct instantiation.
        /// </summary>
        private User() : base() { }

        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        public string FirstName { get; private set; } = default!;

        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        public string LastName { get; private set; } = default!;

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        public string Email { get; private set; } = default!;

        /// <summary>
        /// Gets or sets the hashed password for the user.
        /// </summary>
        public string PasswordHash { get; private set; } = default!;

        /// <summary>
        /// Creates a new instance of the <see cref="User"/> class and raises a <see cref="UserCreatedDomainEvent"/> event.
        /// </summary>
        /// <param name="firstName">The user's first name.</param>
        /// <param name="lastName">The user's last name.</param>
        /// <param name="email">The user's email address.</param>
        /// <param name="passwordHash">The hashed password for the user.</param>
        /// <returns>A new <see cref="User"/> instance.</returns>
        public static User Create(string firstName, string lastName, string email, string passwordHash)
        {
            User user = new User(firstName, lastName, email, passwordHash);

            user.RaiseDomainEvent(new UserCreatedDomainEvent(user));

            return user;
        }

        /// <summary>
        /// Updates the user's first name and last name, and raises a <see cref="UserUpdatedDomainEvent"/> event.
        /// </summary>
        /// <param name="firstName">The new first name for the user.</param>
        /// <param name="lastName">The new last name for the user.</param>
        public void UpdateUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            RaiseDomainEvent(new UserUpdatedDomainEvent(this));
        }

        /// <summary>
        /// Updates the user's email address and raises a <see cref="UserEmailUpdatedDomainEvent"/> event.
        /// </summary>
        /// <param name="email">The new email address for the user.</param>
        public void UpdateEmail(string email)
        {
            Email = email;

            RaiseDomainEvent(new UserEmailUpdatedDomainEvent(this));
        }

        /// <summary>
        /// Updates the user's password hash and raises a <see cref="UserPasswordUpdatedDomainEvent"/> event.
        /// </summary>
        /// <param name="passwordHash">The new hashed password for the user.</param>
        public void UpdatePassword(string passwordHash)
        {
            PasswordHash = passwordHash;

            RaiseDomainEvent(new UserPasswordUpdatedDomainEvent(this));
        }
    }
}
