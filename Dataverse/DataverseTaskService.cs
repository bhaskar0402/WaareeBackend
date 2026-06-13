using Waaree.Api.Models;

namespace Waaree.Api.Dataverse;

// This service will handle Task table operations in Dataverse.
// Tables are created manually in Power Apps, not by this code.
public class DataverseTaskService
{
    public Task<DataverseResult<List<TaskItem>>> GetTasksAsync()
    {
        return Task.FromResult(new DataverseResult<List<TaskItem>>
        {
            Success = false,
            Message = "Dataverse task read is ready for implementation",
            Data = new List<TaskItem>()
        });
    }

    public Task<DataverseResult<TaskItem>> CreateTaskAsync(TaskItem task)
    {
        return Task.FromResult(new DataverseResult<TaskItem>
        {
            Success = false,
            Message = "Dataverse task create is ready for implementation",
            Data = task
        });
    }
}