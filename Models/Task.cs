namespace Waaree.Api.Models;

// This model represents task record
public class TaskItem
{
    public int Id { get; set; }

    public string TaskOwner { get; set; } = "";
    public string Subject { get; set; } = "";
    public DateTime DueDate { get; set; }

    public string Contact { get; set; } = "";
    public string Account { get; set; } = "";

    public string Status { get; set; } = "Not Started";
    public string Priority { get; set; } = "High";

    public string ProductServices { get; set; } = "";
    public string PaymentTerms { get; set; } = "";

    public DateTime? Reminder { get; set; }
    public string Repeat { get; set; } = "";

    public string Description { get; set; } = "";
}