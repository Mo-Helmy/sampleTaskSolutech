namespace Task.Core.Result
{
    public class Error : IEquatable<Error>
    {
        public static readonly Error None = new(string.Empty, string.Empty);
        public static readonly Error NullValue = new("Error.NullValue", "The Specified Result Value is Null");
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }
        public string Code { get; set; }
        public string Message { get; set; }
        // public static implicit operator string(Error error) => error.Code;
        public static implicit operator ResultO(Error error) => ResultO.Failure(error);

        public static implicit operator ResultO<object>(Error error) => ResultO.Failure<object>(error);

        public static Error ValidationErrors(string errors) => new("validationError", errors);

        public static bool operator ==(Error? error1, Error? error2)
        {
            if (error1 is null && error2 is null)
            {
                return true;
            }
            if (error1 is null || error2 is null)
            {
                return false;
            }
            return error1.Code == error2.Code;

        }
        public static bool operator !=(Error? error1, Error? error2)
        {
            return !(error1 == error2);
        }
        public bool Equals(Error? other)
        {
            throw new NotImplementedException();
        }
    }
}
