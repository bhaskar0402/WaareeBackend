using Microsoft.Extensions.Options;
using Waaree.Api.Dataverse;
using Waaree.Api.Models;

namespace Waaree.Api.Services;

// This service handles login logic.
// Memory mode: returns temporary user.
// Dataverse mode: checks App User table in Dataverse.
public class AuthService
{
    private readonly AppSettings _appSettings;
    private readonly DataverseUserService _dataverseUserService;

    public AuthService(
        IOptions<AppSettings> options,
        DataverseUserService dataverseUserService)
    {
        _appSettings = options.Value;
        _dataverseUserService = dataverseUserService;
    }

    public AppUser? LoginByMobile(string mobile)
    {
        // Real Dataverse login
        if (_appSettings.UseDataverse)
        {
            var result = _dataverseUserService.LoginByMobile(mobile);

            if (!result.Success || result.Data == null)
            {
                return null;
            }

            return result.Data;
        }

        // Temporary memory login for local development
        return new AppUser
        {
            Id = 1,
            Name = "Mitesh Vaghela",
            Mobile = mobile,
            Email = "miteshvaghela@waaree.com",
            IsActive = true
        };
    }
}