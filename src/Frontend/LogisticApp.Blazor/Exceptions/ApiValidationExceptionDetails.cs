using Microsoft.AspNetCore.Mvc;

namespace LogisticsApp.Blazor.Exceptions;

public class ApiValidationExceptionDetails : ValidationProblemDetails
{
    public new Dictionary<string, List<string>> Errors { get; set; } = new();
}