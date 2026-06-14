using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Waaree.Api.Models;

namespace Waaree.Api.Dataverse;

// This service handles Task table operations in Dataverse.
// We will use this service whenever the application runs in Dataverse mode.
public class DataverseTaskService
{
    // Used to create Dataverse connection
    private readonly DataverseConnection _dataverseConnection;

    // Constructor Dependency Injection
    public DataverseTaskService(DataverseConnection dataverseConnection)
    {
        _dataverseConnection = dataverseConnection;
    }

    // Get all task records from Dataverse
    public DataverseResult<List<TaskItem>> GetTasks()
    {
        // Create Dataverse client connection
        var client = _dataverseConnection.CreateClient();

        // Check if connection is successful
        if (!client.IsReady)
        {
            return new DataverseResult<List<TaskItem>>
            {
                Success = false,
                Message = client.LastError,
                Data = new List<TaskItem>()
            };
        }

        // Build Dataverse query
        var query = new QueryExpression(DataverseTables.TaskTable)
        {
            ColumnSet = new ColumnSet(
                DataverseTables.TaskSubject,
                DataverseTables.TaskDueDate,
                DataverseTables.TaskStatus,
                DataverseTables.TaskPriority,
                DataverseTables.TaskDescription,
                DataverseTables.TaskContact,
                DataverseTables.TaskAccount
            )
        };

        // Execute query
        var result = client.RetrieveMultiple(query);

        // Convert Dataverse records into TaskItem model list
        var tasks = new List<TaskItem>();

        foreach (var entity in result.Entities)
        {
            tasks.Add(new TaskItem
            {
                // Dataverse record id can be mapped later
                Id = 0,

                // Read values from Dataverse columns
                Subject = entity.GetAttributeValue<string>(
                    DataverseTables.TaskSubject) ?? "",

                DueDate = entity.GetAttributeValue<DateTime>(
                    DataverseTables.TaskDueDate),

                Status = entity.GetAttributeValue<string>(
                    DataverseTables.TaskStatus) ?? "",

                Priority = entity.GetAttributeValue<string>(
                    DataverseTables.TaskPriority) ?? "",

                Description = entity.GetAttributeValue<string>(
                    DataverseTables.TaskDescription) ?? "",

                Contact = entity.GetAttributeValue<string>(
                    DataverseTables.TaskContact) ?? "",

                Account = entity.GetAttributeValue<string>(
                    DataverseTables.TaskAccount) ?? ""
            });
        }

        // Return success response
        return new DataverseResult<List<TaskItem>>
        {
            Success = true,
            Message = "Tasks loaded successfully",
            Data = tasks
        };
    }

    // Create new task record in Dataverse
    public DataverseResult<TaskItem> CreateTask(TaskItem task)
    {
        // Create Dataverse client connection
        var client = _dataverseConnection.CreateClient();

        // Check connection status
        if (!client.IsReady)
        {
            return new DataverseResult<TaskItem>
            {
                Success = false,
                Message = client.LastError,
                Data = task
            };
        }

        // Create new Dataverse entity
        var entity = new Entity(DataverseTables.TaskTable);

        // Map TaskItem fields to Dataverse columns
        entity[DataverseTables.TaskSubject] = task.Subject;
        entity[DataverseTables.TaskDueDate] = task.DueDate;
        entity[DataverseTables.TaskStatus] = task.Status;
        entity[DataverseTables.TaskPriority] = task.Priority;
        entity[DataverseTables.TaskDescription] = task.Description;
        entity[DataverseTables.TaskContact] = task.Contact;
        entity[DataverseTables.TaskAccount] = task.Account;

        // Save record into Dataverse
        client.Create(entity);

        // Return success response
        return new DataverseResult<TaskItem>
        {
            Success = true,
            Message = "Task created successfully",
            Data = task
        };
    }
}