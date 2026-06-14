using Microsoft.Extensions.Options;
using Waaree.Api.Dataverse;
using Waaree.Api.Models;

namespace Waaree.Api.Services;

// This service handles task-related business logic.
// It supports both Memory Mode and Dataverse Mode.
public class TaskService
{
    private readonly AppSettings _appSettings;
    private readonly DataverseTaskService _dataverseTaskService;

    // Temporary memory storage for local testing
    private static List<TaskItem> tasks = new();

    public TaskService(
        IOptions<AppSettings> options,
        DataverseTaskService dataverseTaskService)
    {
        _appSettings = options.Value;
        _dataverseTaskService = dataverseTaskService;
    }

    // Get all tasks
    public List<TaskItem> GetAll()
    {
        // If Dataverse mode is ON, read tasks from Dataverse
        if (_appSettings.UseDataverse)
        {
            var result = _dataverseTaskService.GetTasks();

            if (result.Success && result.Data != null)
            {
                return result.Data;
            }

            return new List<TaskItem>();
        }

        // If Dataverse mode is OFF, read from memory
        return tasks;
    }

    // Add/create new task
    public void Add(TaskItem task)
    {
        // If Dataverse mode is ON, save task into Dataverse
        if (_appSettings.UseDataverse)
        {
            _dataverseTaskService.CreateTask(task);
            return;
        }

        // If Dataverse mode is OFF, save task into memory
        task.Id = tasks.Count + 1;
        tasks.Add(task);
    }
}