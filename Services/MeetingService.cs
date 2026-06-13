using Microsoft.Extensions.Options;
using Waaree.Api.Dataverse;
using Waaree.Api.Models;

namespace Waaree.Api.Services;

// This service handles meeting-related logic.
// Currently it supports memory mode.
// Later Dataverse mode will save/read from Dataverse.
public class MeetingService
{
    private readonly AppSettings _appSettings;

    // Temporary memory storage for local testing
    private static List<Meeting> meetings = new();

    public MeetingService(IOptions<AppSettings> options)
    {
        _appSettings = options.Value;
    }

    public List<Meeting> GetAll()
    {
        // If Dataverse is enabled, later we will call DataverseService here
        if (_appSettings.UseDataverse)
        {
            // Placeholder for future Dataverse logic
            return meetings;
        }

        // Memory mode
        return meetings;
    }

    public void Add(Meeting meeting)
    {
        // Temporary auto ID for memory mode
        meeting.Id = meetings.Count + 1;

        // If Dataverse is enabled, later we will save to Dataverse here
        if (_appSettings.UseDataverse)
        {
            // Placeholder for future Dataverse logic
            meetings.Add(meeting);
            return;
        }

        // Memory mode
        meetings.Add(meeting);
    }
}