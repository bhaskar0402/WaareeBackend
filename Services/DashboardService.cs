namespace Waaree.Api.Services;

// This service prepares dashboard data from task and meeting services.
public class DashboardService
{
    private readonly TaskService _taskService;
    private readonly MeetingService _meetingService;

    public DashboardService(TaskService taskService, MeetingService meetingService)
    {
        _taskService = taskService;
        _meetingService = meetingService;
    }

    public object GetDashboardData()
    {
        var tasks = _taskService.GetAll();
        var meetings = _meetingService.GetAll();

        return new
        {
            todayTasksCount = tasks.Count,
            todayMeetingsCount = meetings.Count,
            openTasks = tasks,
            todayMeetings = meetings
        };
    }
}