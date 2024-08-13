using Library.Domain.Core.BaseType;
using Library.Domain.Users.Events;

namespace Library.Domain.Users;

/// <summary>
/// 
/// </summary>
public sealed class User : AggregateRoot
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    /// <param name="passwordHash"></param>
    private User(string firstName, string lastName, string email, string passwordHash)
        : base(Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
    }

    /// <summary>
    /// 
    /// </summary>
    private User() : base() { }

    /// <summary>
    /// 
    /// </summary>
    public string FirstName { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string  LastName { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string Email{ get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string PasswordHash { get; private set; } = default!;

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
