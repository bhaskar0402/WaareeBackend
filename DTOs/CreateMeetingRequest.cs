namespace Waaree.Api.DTOs;

public class CreateMeetingRequest
{
    public string Title { get; set; } = "";
    public string MeetingVenue { get; set; } = "";
    public string Location { get; set; } = "";
    public DateTime FromDateTime { get; set; }
    public DateTime ToDateTime { get; set; }
    public string Host { get; set; } = "";
    public string Account { get; set; } = "";
    public string Contact { get; set; } = "";
    public string EventStatus { get; set; } = "";
    public string ProductServices { get; set; } = "";
    public string Description { get; set; } = "";
}