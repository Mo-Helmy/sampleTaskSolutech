namespace Task.Core.Exceptions;

public sealed class BusinessRuleException : Exception
{
    public string Message { get; set; }

    public BusinessRuleException(
        string message)
        : base(message)
    {
        Message = message;
    }
}

