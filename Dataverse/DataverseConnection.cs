using Microsoft.Extensions.Options;

namespace Waaree.Api.Dataverse;

// This class will handle Dataverse connection/authentication.
// Later we will add Interactive Login code here.
public class DataverseConnection
{
    private readonly AppSettings _appSettings;
    private readonly DataverseSettings _dataverseSettings;

    public DataverseConnection(
        IOptions<AppSettings> appOptions,
        IOptions<DataverseSettings> dataverseOptions)
    {
        _appSettings = appOptions.Value;
        _dataverseSettings = dataverseOptions.Value;
    }

    // This tells whether app should use Dataverse or memory mode
    public bool IsDataverseEnabled()
    {
        return _appSettings.UseDataverse;
    }

    // This returns current connection status
    public string GetStatus()
    {
        if (!_appSettings.UseDataverse)
        {
            return "Memory Mode Enabled";
        }

        if (string.IsNullOrWhiteSpace(_dataverseSettings.EnvironmentUrl))
        {
            return "Dataverse Mode Enabled, but EnvironmentUrl is missing";
        }

        return $"Dataverse Mode Enabled for {_dataverseSettings.EnvironmentUrl}";
    }
}