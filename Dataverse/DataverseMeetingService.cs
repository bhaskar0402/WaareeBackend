using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Waaree.Api.Models;

namespace Waaree.Api.Dataverse;

// This service handles Meeting table operations in Dataverse.
public class DataverseMeetingService
{
    private readonly DataverseConnection _dataverseConnection;

    public DataverseMeetingService(DataverseConnection dataverseConnection)
    {
        _dataverseConnection = dataverseConnection;
    }

    // Get all meetings from Dataverse
    public DataverseResult<List<Meeting>> GetMeetings()
    {
        var client = _dataverseConnection.CreateClient();

        // Check connection
        if (!client.IsReady)
        {
            return new DataverseResult<List<Meeting>>
            {
                Success = false,
                Message = client.LastError,
                Data = new List<Meeting>()
            };
        }

        // Build query
        var query = new QueryExpression(DataverseTables.MeetingTable)
        {
            ColumnSet = new ColumnSet(
                DataverseTables.MeetingTitle,
                DataverseTables.MeetingFromDateTime,
                DataverseTables.MeetingToDateTime,
                DataverseTables.MeetingLocation,
                DataverseTables.MeetingDescription,
                DataverseTables.MeetingContact,
                DataverseTables.MeetingAccount
            )
        };

        // Execute query
        var result = client.RetrieveMultiple(query);

        var meetings = new List<Meeting>();

        foreach (var entity in result.Entities)
        {
            meetings.Add(new Meeting
            {
                Id = 0,

                Title = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingTitle) ?? "",

                FromDateTime = entity.GetAttributeValue<DateTime>(
                    DataverseTables.MeetingFromDateTime),

                ToDateTime = entity.GetAttributeValue<DateTime>(
                    DataverseTables.MeetingToDateTime),

                Location = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingLocation) ?? "",

                Description = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingDescription) ?? "",

                Contact = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingContact) ?? "",

                Account = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingAccount) ?? ""
            });
        }

        return new DataverseResult<List<Meeting>>
        {
            Success = true,
            Message = "Meetings loaded successfully",
            Data = meetings
        };
    }

    // Create new meeting in Dataverse
    public DataverseResult<Meeting> CreateMeeting(Meeting meeting)
    {
        var client = _dataverseConnection.CreateClient();

        if (!client.IsReady)
        {
            return new DataverseResult<Meeting>
            {
                Success = false,
                Message = client.LastError,
                Data = meeting
            };
        }

        var entity = new Entity(DataverseTables.MeetingTable);

        entity[DataverseTables.MeetingTitle] = meeting.Title;
        entity[DataverseTables.MeetingFromDateTime] = meeting.FromDateTime;
        entity[DataverseTables.MeetingToDateTime] = meeting.ToDateTime;
        entity[DataverseTables.MeetingLocation] = meeting.Location;
        entity[DataverseTables.MeetingDescription] = meeting.Description;
        entity[DataverseTables.MeetingContact] = meeting.Contact;
        entity[DataverseTables.MeetingAccount] = meeting.Account;

        client.Create(entity);

        return new DataverseResult<Meeting>
        {
            Success = true,
            Message = "Meeting created successfully",
            Data = meeting
        };
    }
}