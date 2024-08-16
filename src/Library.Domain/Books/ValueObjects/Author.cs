using Library.Domain.Core.BaseType;
using Library.Domain.Core.BaseType.Results;

namespace Library.Domain.Books.ValueObjects;

public sealed class Author : ValueObject
{
    public const int MaxLength = 100;

    private Author(string value) => Value = value;

    public string Value { get; }

    public static Result<Author> Creat(string author) =>
        Result.Create(author, Error.None)
              .Ensure(a => string.IsNullOrEmpty(a), Error.None)
              .Ensure(a => a.Length < MaxLength, Error.None)
              .Map(a => new Author(a));

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
