using Waaree.Api.Models;

namespace Waaree.Api.Dataverse;

// This service will handle AppUser table operations in Dataverse.
// Tables are created manually in Power Apps, not by this code.
public class DataverseUserService
{
    public Task<DataverseResult<AppUser>> LoginByMobileAsync(string mobile)
    {
        return Task.FromResult(new DataverseResult<AppUser>
        {
            Success = false,
            Message = "Dataverse user login is ready for implementation",
            Data = null
        });
    }
}