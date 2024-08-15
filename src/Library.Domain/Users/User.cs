using Library.Domain.Core.Abstractions;
using Library.Domain.Core.BaseType;
using Library.Domain.Users.Events;

namespace Library.Domain.Users
{
    public  class User : AggregateRoot , IAuditableEntity, ISoftDeletableEntity
    {
        private User(string firstName, string lastName, string email, string passwordHash)
            : base(Guid.NewGuid())
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
        }
      
        private User() : base() { }
   
        public string FirstName { get; private set; } = default!;

        public string LastName { get; private set; } = default!;

        public string Email { get; private set; } = default!;

        public string PasswordHash { get; private set; } = default!;

        public DateTime CreatedOnUtc { get; }

        public DateTime? ModifiedOnUtc { get; private set; }

        public DateTime? DeletedOnUtc { get; private set; }

        public bool Deleted { get; private set; }

        public static User Create(string firstName, string lastName, string email, string passwordHash)
        {
            User user = new User(firstName, lastName, email, passwordHash);

           user.RaiseDomainEvent(new UserCreatedDomainEvent(user));

            return user;
        }

        public void UpdateUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            RaiseDomainEvent(new UserUpdatedDomainEvent(this));
        }

        public void UpdateEmail(string email)
        {
            Email = email;

            RaiseDomainEvent(new UserEmailUpdatedDomainEvent(this));
        }

        public void UpdatePassword(string passwordHash)
        {
            PasswordHash = passwordHash;

            RaiseDomainEvent(new UserPasswordUpdatedDomainEvent(this));
        }
    }
}
