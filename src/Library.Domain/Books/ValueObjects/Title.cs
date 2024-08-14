using Library.Domain.Core.BaseType;

namespace Library.Domain.Books.ValueObjects;

public sealed class Title : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
