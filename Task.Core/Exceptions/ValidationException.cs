namespace Task.Core.Exceptions;

public class ValidationException(
    string displayMessage,
    int messageCode) : Exception(displayMessage)
{
    public string DisplayMessage { get; set; } = displayMessage;
    public int MessageCode { get; set; } = messageCode;
}