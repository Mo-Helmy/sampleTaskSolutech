namespace Task.Core.Result;

public class ErrorClass
{
    public ErrorClass(string message, string key, int code)
    {
        Key = key;
        Message = message;
        Code = code;
        Errors = [];
    }

    public ErrorClass(List<ValidationError> errors)
    {
        Errors = errors;
    }
    public string Key { get; set; }
    public int Code { get; set; }
    public string Message { get; set; }
    public List<ValidationError> Errors { get; set; }
}