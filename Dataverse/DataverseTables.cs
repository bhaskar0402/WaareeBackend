namespace Waaree.Api.Dataverse;

// Stores Dataverse table and column logical names.
// These tables are created manually in Power Apps.
public static class DataverseTables
{
    // Table logical names
    public const string AppUserTable = "cr034_appuser";
    public const string TaskTable = "cr034_task";
    public const string MeetingTable = "cr034_meeting";

    // App User column logical names
    public const string AppUserName = "cr034_name";
    public const string AppUserMobile = "cr034_mobile";
    public const string AppUserEmail = "cr034_email";
    public const string AppUserIsActive = "cr034_isactive";

    // Task column logical names
    public const string TaskSubject = "cr034_subject";
    public const string TaskDueDate = "cr034_duedate";
    public const string TaskStatus = "cr034_status";
    public const string TaskPriority = "cr034_priority";
    public const string TaskDescription = "cr034_description";
    public const string TaskContact = "cr034_contact";
    public const string TaskAccount = "cr034_account";

    // Meeting column logical names
    public const string MeetingTitle = "cr034_title";
    public const string MeetingFromDateTime = "cr034_fromdatetime";
    public const string MeetingToDateTime = "cr034_todatetime";
    public const string MeetingLocation = "cr034_location";
    public const string MeetingDescription = "cr034_description";
    public const string MeetingContact = "cr034_contact";
    public const string MeetingAccount = "cr034_account";
}