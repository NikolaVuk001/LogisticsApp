namespace LogisticsApp.Domain.Exceptions;

public class EntityNotFoundException(string recourceType, string resourceIdentifier)
    : Exception($"{recourceType} with id: {resourceIdentifier} doesn't exist.")
{

}