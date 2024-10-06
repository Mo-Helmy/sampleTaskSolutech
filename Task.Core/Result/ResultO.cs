namespace Task.Core.Result
{
    public class ResultO
    {
        protected internal ResultO(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
            {
                throw new InvalidOperationException();
            }
            if (!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException();
            }
            IsSuccess = isSuccess;
            Error = error;
        }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        public static ResultO Success() => new(true, Error.None);
        public static ResultO Failure(Error error) => new(false, error);

        public static ResultO<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
        public static ResultO<TValue> Failure<TValue>(Error error) => new(default, false, error);
        public static ResultO<TValue> Create<TValue>(TValue? value) =>
            value is not null ? Success(value) : Failure<TValue>(Error.NullValue);





    }
}
