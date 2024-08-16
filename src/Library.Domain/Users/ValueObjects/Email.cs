using Library.Domain.Core.BaseType;
using Library.Domain.Core.BaseType.Results;
using System.Text.RegularExpressions;

namespace Library.Domain.Users.ValueObjects;

public sealed class Email : ValueObject
{
    public const int MaxLength = 100;

    public const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    
    private Email(string value) => Value = value;

    public string Value { get; private set; }

    public static Result<Email> Create(string email) =>
        Result.Create(email, Error.None)
              .Ensure(e => string.IsNullOrEmpty(e), Error.None)
              .Ensure(e => Regex.IsMatch(email, EmailPattern), Error.None)
              .Map(e => new Email(e));

    public override string ToString() => Value;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
