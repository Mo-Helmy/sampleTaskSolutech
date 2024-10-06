namespace Task.Core.Exceptions;

public sealed class NotFoundException : Exception
{
    public string DisplayMessage { get; set; }

    public NotFoundException(string message) : base(message)
    {
        DisplayMessage = message;
    }
}
