using Library.Domain.Core.BaseType;
using Library.Domain.Core.BaseType.Results;

namespace Library.Domain.Users.ValueObjects;

public sealed class FirstName : ValueObject
{
    public const int MaxLength = 100;

    private FirstName(string value) => Value = value;

    public string Value { get; }

    public static implicit operator string(FirstName firstName) => firstName.Value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstName"></param>
    /// <returns></returns>
    public static Result<FirstName> Create(string firstName) =>
        Result.Create(firstName, Error.None)
              .Ensure(f => !string.IsNullOrEmpty(f), Error.None)
              .Ensure(f => f.Length <= MaxLength, Error.None)
              .Map(f => new FirstName(f));

    public override string ToString() => Value;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
