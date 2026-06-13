namespace Waaree.Api.Dataverse;

// Generic response class for Dataverse operations.
public class DataverseResult<T>
{
    // Indicates success or failure
    public bool Success { get; set; }

    // Message returned by operation
    public string Message { get; set; } = string.Empty;

    // Returned data
    public T? Data { get; set; }
}