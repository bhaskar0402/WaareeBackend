namespace Waaree.Api.DTOs;

// DTO used when Flutter creates a new Task
public class CreateTaskRequest
{
    public string TaskOwner { get; set; } = "";
    public string Subject { get; set; } = "";
    public DateTime DueDate { get; set; }
    public string Contact { get; set; } = "";
    public string Account { get; set; } = "";
    public string Status { get; set; } = "";
    public string Priority { get; set; } = "";
    public string ProductServices { get; set; } = "";
    public string PaymentTerms { get; set; } = "";
    public DateTime? Reminder { get; set; }
    public string Repeat { get; set; } = "";

    public string Description { get; set; } = "";
}