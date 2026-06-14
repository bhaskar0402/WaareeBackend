using Microsoft.Extensions.Options;
using Waaree.Api.Dataverse;
using Waaree.Api.Models;

namespace Waaree.Api.Services;

// This service handles meeting-related business logic.
// It supports both Memory Mode and Dataverse Mode.
public class MeetingService
{
    private readonly AppSettings _appSettings;
    private readonly DataverseMeetingService _dataverseMeetingService;

    // Temporary memory storage for local testing
    private static List<Meeting> meetings = new();

    public MeetingService(
        IOptions<AppSettings> options,
        DataverseMeetingService dataverseMeetingService)
    {
        _appSettings = options.Value;
        _dataverseMeetingService = dataverseMeetingService;
    }

    // Get all meetings
    public List<Meeting> GetAll()
    {
        // If Dataverse mode is ON, read meetings from Dataverse
        if (_appSettings.UseDataverse)
        {
            var result = _dataverseMeetingService.GetMeetings();

            if (result.Success && result.Data != null)
            {
                return result.Data;
            }

            return new List<Meeting>();
        }

        // If Dataverse mode is OFF, read from memory
        return meetings;
    }

    // Add/create new meeting
    public void Add(Meeting meeting)
    {
        // If Dataverse mode is ON, save meeting into Dataverse
        if (_appSettings.UseDataverse)
        {
            _dataverseMeetingService.CreateMeeting(meeting);
            return;
        }

        // If Dataverse mode is OFF, save meeting into memory
        meeting.Id = meetings.Count + 1;
        meetings.Add(meeting);
    }
}