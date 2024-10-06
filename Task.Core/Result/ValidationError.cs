namespace Task.Core.Result;
public class ValidationError(string key, List<string> errorMessages)
{
    public string Key { get; set; } = key;
    public List<string> ErrorMessages { get; set; } = errorMessages;
}