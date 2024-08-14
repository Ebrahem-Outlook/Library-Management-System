using Library.Domain.Core.BaseType;

namespace Library.Domain.Users.ValueObjects;

public sealed class LastName : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
