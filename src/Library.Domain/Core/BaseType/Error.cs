namespace Library.Domain.Core.BaseType;

public sealed class Error
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }

    public string Message { get; }

    public static Error None => new Error(string.Empty, string.Empty);
}
