namespace Library.Domain.Core.BaseType.Results;

public class Result<TValue> : Result
{
    public Result(bool isSuccess, Error error) : base(isSuccess, error)
    {
    }
}
