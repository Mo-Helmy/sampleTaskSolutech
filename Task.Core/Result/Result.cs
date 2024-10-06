namespace Task.Core.Result;
public class Result<T>
{
    public T? Value { get; set; }

    public ErrorClass? Error { get; set; }

    private Result(T value) => Value = value;

    private Result(ErrorClass error) => Error = error;

    public static Result<T> Success(T response) => new(response);

    public static Result<T> IsFailure(ErrorClass error) => new(error);

    public static implicit operator Result<T>(ErrorClass error) => new(error);
}