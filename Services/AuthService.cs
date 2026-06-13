using Microsoft.Extensions.Options;
using Waaree.Api.Dataverse;
using Waaree.Api.Models;

namespace Waaree.Api.Services;

// This service handles login logic.
// Current mode: memory login.
// Future mode: check AppUser table in Dataverse.
public class AuthService
{
    private readonly AppSettings _appSettings;

    public AuthService(IOptions<AppSettings> options)
    {
        _appSettings = options.Value;
    }

    public AppUser LoginByMobile(string mobile)
    {
        // Later, if Dataverse is enabled, we will search AppUser table here
        if (_appSettings.UseDataverse)
        {
            // Placeholder for future Dataverse user lookup
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