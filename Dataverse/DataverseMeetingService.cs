using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Waaree.Api.Models;

namespace Waaree.Api.Dataverse;

// This service handles Meeting table operations in Dataverse.
public class DataverseMeetingService
{
    // Used to create Dataverse connection
    private readonly DataverseConnection _dataverseConnection;

    // Constructor Dependency Injection
    public DataverseMeetingService(DataverseConnection dataverseConnection)
    {
        _dataverseConnection = dataverseConnection;
    }

    // Get all meetings from Dataverse
    public DataverseResult<List<Meeting>> GetMeetings()
    {
        // Create Dataverse client connection
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

        // Build Dataverse query and select only the columns our API needs
        var query = new QueryExpression(DataverseTables.MeetingTable)
        {
            ColumnSet = new ColumnSet(
                DataverseTables.MeetingTitle,
                DataverseTables.MeetingVenue,
                DataverseTables.MeetingLocation,
                DataverseTables.MeetingFromDateTime,
                DataverseTables.MeetingToDateTime,
                DataverseTables.MeetingHost,
                DataverseTables.MeetingParticipants,
                DataverseTables.MeetingAccount,
                DataverseTables.MeetingContact,
                DataverseTables.MeetingEventStatus,
                DataverseTables.MeetingProductServices,
                DataverseTables.MeetingRepeat,
                DataverseTables.MeetingDescription
            )
        };

        // Execute query
        var result = client.RetrieveMultiple(query);

        // Convert Dataverse records into Meeting model list
        var meetings = new List<Meeting>();

        foreach (var entity in result.Entities)
        {
            meetings.Add(new Meeting
            {
                // Dataverse GUID can be mapped later if needed
                Id = 0,

                Title = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingTitle) ?? "",

                MeetingVenue = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingVenue) ?? "",

                Location = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingLocation) ?? "",

                FromDateTime = entity.GetAttributeValue<DateTime>(
                    DataverseTables.MeetingFromDateTime),

                ToDateTime = entity.GetAttributeValue<DateTime>(
                    DataverseTables.MeetingToDateTime),

                Host = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingHost) ?? "",

                Participants = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingParticipants) ?? "",

                Account = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingAccount) ?? "",

                Contact = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingContact) ?? "",

                EventStatus = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingEventStatus) ?? "",

                ProductServices = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingProductServices) ?? "",

                Repeat = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingRepeat) ?? "",

                Description = entity.GetAttributeValue<string>(
                    DataverseTables.MeetingDescription) ?? ""
            });
        }

        // Return success response
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
        // Create Dataverse client connection
        var client = _dataverseConnection.CreateClient();

        // Check connection status
        if (!client.IsReady)
        {
            return new DataverseResult<Meeting>
            {
                Success = false,
                Message = client.LastError,
                Data = meeting
            };
        }

        // Create new Dataverse entity for Meeting table
        var entity = new Entity(DataverseTables.MeetingTable);

        // Map Meeting model fields to Dataverse columns
        entity[DataverseTables.MeetingTitle] = meeting.Title;
        entity[DataverseTables.MeetingVenue] = meeting.MeetingVenue;
        entity[DataverseTables.MeetingLocation] = meeting.Location;
        entity[DataverseTables.MeetingFromDateTime] = meeting.FromDateTime;
        entity[DataverseTables.MeetingToDateTime] = meeting.ToDateTime;
        entity[DataverseTables.MeetingHost] = meeting.Host;
        entity[DataverseTables.MeetingParticipants] = meeting.Participants;
        entity[DataverseTables.MeetingAccount] = meeting.Account;
        entity[DataverseTables.MeetingContact] = meeting.Contact;
        entity[DataverseTables.MeetingEventStatus] = meeting.EventStatus;
        entity[DataverseTables.MeetingProductServices] = meeting.ProductServices;
        entity[DataverseTables.MeetingRepeat] = meeting.Repeat;
        entity[DataverseTables.MeetingDescription] = meeting.Description;

        // Save record into Dataverse
        client.Create(entity);

        // Return success response
        return new DataverseResult<Meeting>
        {
            Success = true,
            Message = "Meeting created successfully",
            Data = meeting
        };
    }
}