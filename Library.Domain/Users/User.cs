using Library.Domain.Core.BaseType;

namespace Library.Domain.Users;

public sealed class User : AggregateRoot
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email{ get; private set; }
    public FirstName FirstName { get; private set; }
}
