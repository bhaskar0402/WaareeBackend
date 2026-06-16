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

        // Build Dataverse query and select only the columns our API needs
        var query = new QueryExpression(DataverseTables.TaskTable)
        {
            ColumnSet = new ColumnSet(
                DataverseTables.TaskOwner,
                DataverseTables.TaskSubject,
                DataverseTables.TaskDueDate,
                DataverseTables.TaskContact,
                DataverseTables.TaskAccount,
                DataverseTables.TaskStatus,
                DataverseTables.TaskPriority,
                DataverseTables.TaskProductServices,
                DataverseTables.TaskPaymentTerms,
                DataverseTables.TaskReminder,
                DataverseTables.TaskRepeat,
                DataverseTables.TaskDescription
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
                // Dataverse GUID can be mapped later if needed
                Id = 0,

                TaskOwner = entity.GetAttributeValue<string>(
                    DataverseTables.TaskOwner) ?? "",

                Subject = entity.GetAttributeValue<string>(
                    DataverseTables.TaskSubject) ?? "",

                DueDate = entity.GetAttributeValue<DateTime>(
                    DataverseTables.TaskDueDate),

                Contact = entity.GetAttributeValue<string>(
                    DataverseTables.TaskContact) ?? "",

                Account = entity.GetAttributeValue<string>(
                    DataverseTables.TaskAccount) ?? "",

                Status = entity.GetAttributeValue<string>(
                    DataverseTables.TaskStatus) ?? "",

                Priority = entity.GetAttributeValue<string>(
                    DataverseTables.TaskPriority) ?? "",

                ProductServices = entity.GetAttributeValue<string>(
                    DataverseTables.TaskProductServices) ?? "",

                PaymentTerms = entity.GetAttributeValue<string>(
                    DataverseTables.TaskPaymentTerms) ?? "",

                Reminder = entity.Contains(DataverseTables.TaskReminder)
                    ? entity.GetAttributeValue<DateTime>(DataverseTables.TaskReminder)
                    : null,

                Repeat = entity.GetAttributeValue<string>(
                    DataverseTables.TaskRepeat) ?? "",

                Description = entity.GetAttributeValue<string>(
                    DataverseTables.TaskDescription) ?? ""
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

        // Create new Dataverse entity for Task table
        var entity = new Entity(DataverseTables.TaskTable);

        // Map TaskItem model fields to Dataverse columns
        entity[DataverseTables.TaskOwner] = task.TaskOwner;
        entity[DataverseTables.TaskSubject] = task.Subject;
        entity[DataverseTables.TaskDueDate] = task.DueDate;
        entity[DataverseTables.TaskContact] = task.Contact;
        entity[DataverseTables.TaskAccount] = task.Account;
        entity[DataverseTables.TaskStatus] = task.Status;
        entity[DataverseTables.TaskPriority] = task.Priority;
        entity[DataverseTables.TaskProductServices] = task.ProductServices;
        entity[DataverseTables.TaskPaymentTerms] = task.PaymentTerms;
        entity[DataverseTables.TaskRepeat] = task.Repeat;
        entity[DataverseTables.TaskDescription] = task.Description;

        // Only send Reminder if user provided it
        if (task.Reminder.HasValue)
        {
            entity[DataverseTables.TaskReminder] = task.Reminder.Value;
        }

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