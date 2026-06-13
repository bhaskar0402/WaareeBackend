namespace Waaree.Api.Dataverse;

// This class stores Dataverse table and column logical names.
// Later, after tables are created in Dataverse, we will update these names.
public static class DataverseTables
{
    // Custom table logical names
    public const string AppUserTable = "wa_appuser";
    public const string TaskTable = "wa_task";
    public const string MeetingTable = "wa_meeting";

    // AppUser columns
    public const string AppUserName = "wa_name";
    public const string AppUserMobile = "wa_mobile";
    public const string AppUserEmail = "wa_email";
    public const string AppUserIsActive = "wa_isactive";

    // Task columns
    public const string TaskSubject = "wa_subject";
    public const string TaskDueDate = "wa_duedate";
    public const string TaskStatus = "wa_status";
    public const string TaskPriority = "wa_priority";
    public const string TaskDescription = "wa_description";

    // Meeting columns
    public const string MeetingTitle = "wa_title";
    public const string MeetingVenue = "wa_meetingvenue";
    public const string MeetingLocation = "wa_location";
    public const string MeetingFromDateTime = "wa_fromdatetime";
    public const string MeetingToDateTime = "wa_todatetime";
    public const string MeetingDescription = "wa_description";
}