namespace LogisticsApp.Blazor.Exceptions;

public class ApiException(string message) : Exception(message)
{

}