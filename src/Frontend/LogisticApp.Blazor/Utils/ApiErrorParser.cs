using System.Text.Json;

namespace LogisticsApp.Blazor.Utils;

public class ApiErrorParser
{
    public static Dictionary<string, string[]> ParseErrors(Dictionary<string, object>? errorResponse)
    {
        if (errorResponse == null || !errorResponse.ContainsKey("errors"))
        {
            return [];
        }

        var errors = errorResponse["errors"] as JsonElement?;

        if (errors == null)
        {
            return [];
        }

        var errorList = errors.Value.Deserialize<Dictionary<string, string[]>>();

        return errorList ?? [];
    }
}