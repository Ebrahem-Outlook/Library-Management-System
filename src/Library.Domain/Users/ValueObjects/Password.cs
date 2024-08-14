using Library.Domain.Core.BaseType;

namespace Library.Domain.Users.ValueObjects;

public sealed class Password : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
