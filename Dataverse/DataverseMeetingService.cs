using Waaree.Api.Models;

namespace Waaree.Api.Dataverse;

// This service will handle Meeting table operations in Dataverse.
// Tables are created manually in Power Apps, not by this code.
public class DataverseMeetingService
{
    public Task<DataverseResult<List<Meeting>>> GetMeetingsAsync()
    {
        return Task.FromResult(new DataverseResult<List<Meeting>>
        {
            Success = false,
            Message = "Dataverse meeting read is ready for implementation",
            Data = new List<Meeting>()
        });
    }

    public Task<DataverseResult<Meeting>> CreateMeetingAsync(Meeting meeting)
    {
        return Task.FromResult(new DataverseResult<Meeting>
        {
            Success = false,
            Message = "Dataverse meeting create is ready for implementation",
            Data = meeting
        });
    }
}