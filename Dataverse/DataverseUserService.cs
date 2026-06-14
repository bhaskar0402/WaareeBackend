using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Waaree.Api.Models;

namespace Waaree.Api.Dataverse;

// Handles AppUser table operations in Dataverse.
public class DataverseUserService
{
    private readonly DataverseConnection _dataverseConnection;

    public DataverseUserService(DataverseConnection dataverseConnection)
    {
        _dataverseConnection = dataverseConnection;
    }

    // Create App User record in Dataverse
    public DataverseResult<AppUser> CreateAppUser(AppUser user)
    {
        var client = _dataverseConnection.CreateClient();

        if (!client.IsReady)
        {
            return new DataverseResult<AppUser>
            {
                Success = false,
                Message = client.LastError
            };
        }

        var entity = new Entity(DataverseTables.AppUserTable);

        entity[DataverseTables.AppUserName] = user.Name;
        entity[DataverseTables.AppUserMobile] = user.Mobile;
        entity[DataverseTables.AppUserEmail] = user.Email;
        entity[DataverseTables.AppUserIsActive] = user.IsActive;

        client.Create(entity);

        return new DataverseResult<AppUser>
        {
            Success = true,
            Message = "App user created successfully",
            Data = user
        };
    }

    // Find App User by mobile number
    public DataverseResult<AppUser> LoginByMobile(string mobile)
    {
        var client = _dataverseConnection.CreateClient();

        if (!client.IsReady)
        {
            return new DataverseResult<AppUser>
            {
                Success = false,
                Message = client.LastError
            };
        }

        var query = new QueryExpression(DataverseTables.AppUserTable)
        {
            ColumnSet = new ColumnSet(
                DataverseTables.AppUserName,
                DataverseTables.AppUserMobile,
                DataverseTables.AppUserEmail,
                DataverseTables.AppUserIsActive
            )
        };

        query.Criteria.AddCondition(
            DataverseTables.AppUserMobile,
            ConditionOperator.Equal,
            mobile
        );

        var result = client.RetrieveMultiple(query);

        if (result.Entities.Count == 0)
        {
            return new DataverseResult<AppUser>
            {
                Success = false,
                Message = "User not found"
            };
        }

        var entity = result.Entities[0];

        var user = new AppUser
        {
            Id = 1,
            Name = entity.GetAttributeValue<string>(DataverseTables.AppUserName) ?? "",
            Mobile = entity.GetAttributeValue<string>(DataverseTables.AppUserMobile) ?? "",
            Email = entity.GetAttributeValue<string>(DataverseTables.AppUserEmail) ?? "",
            IsActive = entity.GetAttributeValue<bool>(DataverseTables.AppUserIsActive)
        };

        return new DataverseResult<AppUser>
        {
            Success = true,
            Message = "Login successful",
            Data = user
        };
    }
}