namespace LogisticsApp.Blazor.Exceptions;

public class ApiValidationException : Exception
{
    public Dictionary<string, string> Errors { get; }

    public ApiValidationException(Dictionary<string, string> errors)
    {
        Errors = errors;
    }
}