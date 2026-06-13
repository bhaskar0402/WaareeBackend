using Microsoft.Extensions.Options;
using Waaree.Api.Dataverse;
using Waaree.Api.Models;

namespace Waaree.Api.Services;

// This service handles task-related logic.
// Currently it supports memory mode.
// Later Dataverse mode will save/read from Dataverse.
public class TaskService
{
    private readonly AppSettings _appSettings;

    // Temporary memory storage for local testing
    private static List<TaskItem> tasks = new();

    public TaskService(IOptions<AppSettings> options)
    {
        _appSettings = options.Value;
    }

    public List<TaskItem> GetAll()
    {
        // If Dataverse is enabled, later we will call DataverseService here
        if (_appSettings.UseDataverse)
        {
            // Placeholder for future Dataverse logic
            return tasks;
        }

        // Memory mode
        return tasks;
    }

    public void Add(TaskItem task)
    {
        // Temporary auto ID for memory mode
        task.Id = tasks.Count + 1;

        // If Dataverse is enabled, later we will save to Dataverse here
        if (_appSettings.UseDataverse)
        {
            // Placeholder for future Dataverse logic
            tasks.Add(task);
            return;
        }

        // Memory mode
        tasks.Add(task);
    }
}