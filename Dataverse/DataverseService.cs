using Microsoft.Extensions.Options;
using Waaree.Api.Models;

namespace Waaree.Api.Dataverse;

// This service is the single place where our API will talk to Dataverse.
public class DataverseService
{
    private readonly AppSettings _appSettings;

    // AppSettings is read from appsettings.json
    public DataverseService(IOptions<AppSettings> options)
    {
        _appSettings = options.Value;
    }

    // Tells whether app is running in Dataverse mode or Memory mode
    public bool IsDataverseEnabled()
    {
        return _appSettings.UseDataverse;
    }

    // Used by health check API
    public string GetStatus()
    {
        return _appSettings.UseDataverse
            ? "Dataverse Mode Enabled"
            : "Memory Mode Enabled";
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