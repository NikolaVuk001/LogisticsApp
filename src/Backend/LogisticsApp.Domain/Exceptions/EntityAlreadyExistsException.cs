namespace LogisticsApp.Domain.Exceptions;

public class EntityAlreadyExistsException(string recourceType, string resourceIdentifier)
    : Exception($"{recourceType} with id: {resourceIdentifier} already exist.")
{

}