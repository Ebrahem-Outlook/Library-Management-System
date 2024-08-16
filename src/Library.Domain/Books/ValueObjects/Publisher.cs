using Library.Domain.Core.BaseType;
using Library.Domain.Core.BaseType.Results;

namespace Library.Domain.Books.ValueObjects;

public sealed class Publisher : ValueObject
{
    public const int MaxLength = 100;

    private Publisher(string value) => Value = value;

    public string Value { get; }

    public static Result<Publisher> Create(string publisher) =>
        Result.Create(publisher, Error.None)
              .Ensure(p => string.IsNullOrEmpty(p), Error.None)
              .Ensure(p => publisher.Length < MaxLength, Error.None)
              .Map(p => new Publisher(publisher));

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
