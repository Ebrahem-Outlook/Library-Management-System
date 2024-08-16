using Library.Domain.Core.Abstractions;
using Library.Domain.Core.BaseType;
using Library.Domain.Users.Events;
using Library.Domain.Users.ValueObjects;

namespace Library.Domain.Users
{
    public  class User : AggregateRoot , IAuditableEntity, ISoftDeletableEntity
    {
        private User(FirstName firstName, LastName lastName, Email email, Password passwordHash)
            : base(Guid.NewGuid())
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            CreatedOnUtc = DateTime.UtcNow;
        }
      
        private User() : base() { }
   
        public FirstName FirstName { get; private set; } = default!;

        public LastName LastName { get; private set; } = default!;

        public Email Email { get; private set; } = default!;

        public Password PasswordHash { get; private set; } = default!;

        public DateTime CreatedOnUtc { get; }

        public DateTime? ModifiedOnUtc { get; private set; }

        public DateTime? DeletedOnUtc { get; private set; }

        public bool Deleted { get; private set; }

        public static User Create(FirstName firstName, LastName lastName, Email email, Password passwordHash)
        {
            User user = new User(firstName, lastName, email, passwordHash);

           user.RaiseDomainEvent(new UserCreatedDomainEvent(user));

            return user;
        }

        public void UpdateUser(FirstName firstName, LastName lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            ModifiedOnUtc = DateTime.UtcNow;

            RaiseDomainEvent(new UserUpdatedDomainEvent(this));
        }

        public void UpdateEmail(Email email)
        {
            Email = email;
            ModifiedOnUtc = DateTime.UtcNow;

            RaiseDomainEvent(new UserEmailUpdatedDomainEvent(this));
        }

        public void UpdatePassword(Password passwordHash)
        {
            PasswordHash = passwordHash;
            ModifiedOnUtc = DateTime.UtcNow;

            RaiseDomainEvent(new UserPasswordUpdatedDomainEvent(this));
        }
    }
}
