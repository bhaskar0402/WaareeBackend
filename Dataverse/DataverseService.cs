using Microsoft.Extensions.Options;
using Waaree.Api.Models;

namespace Waaree.Api.Dataverse;

// This service is the main wrapper where our API talks to Dataverse.
// It calls DataverseConnection for authentication/connection.
public class DataverseService
{
    private readonly DataverseConnection _dataverseConnection;

    public DataverseService(DataverseConnection dataverseConnection)
    {
        _dataverseConnection = dataverseConnection;
    }

    // Tells whether app is running in Dataverse mode or Memory mode
    public bool IsDataverseEnabled()
    {
        return _dataverseConnection.IsDataverseEnabled();
    }

    // Used by health check API
    public string GetStatus()
    {
        return _dataverseConnection.GetStatus();
    }

    // This checks real Dataverse connection
    public string TestConnection()
    {
        return _dataverseConnection.TestConnection();
    }

    // Later this will check AppUser table in Dataverse
    public Task<DataverseResult<AppUser>> LoginByMobileAsync(string mobile)
    {
        return Task.FromResult(new DataverseResult<AppUser>
        {
            Success = false,
            Message = "Dataverse login is not implemented yet",
            Data = null
        });
    }

    // Later this will read task records from Dataverse
    public Task<DataverseResult<List<TaskItem>>> GetTasksAsync()
    {
        return Task.FromResult(new DataverseResult<List<TaskItem>>
        {
            Success = false,
            Message = "Dataverse task read is not implemented yet",
            Data = new List<TaskItem>()
        });
    }

    // Later this will create task record in Dataverse
    public Task<DataverseResult<TaskItem>> CreateTaskAsync(TaskItem task)
    {
        return Task.FromResult(new DataverseResult<TaskItem>
        {
            Success = false,
            Message = "Dataverse task create is not implemented yet",
            Data = task
        });
    }

    // Later this will read meeting records from Dataverse
    public Task<DataverseResult<List<Meeting>>> GetMeetingsAsync()
    {
        return Task.FromResult(new DataverseResult<List<Meeting>>
        {
            Success = false,
            Message = "Dataverse meeting read is not implemented yet",
            Data = new List<Meeting>()
        });
    }

    // Later this will create meeting record in Dataverse
    public Task<DataverseResult<Meeting>> CreateMeetingAsync(Meeting meeting)
    {
        return Task.FromResult(new DataverseResult<Meeting>
        {
            Success = false,
            Message = "Dataverse meeting create is not implemented yet",
            Data = meeting
        });
    }
}