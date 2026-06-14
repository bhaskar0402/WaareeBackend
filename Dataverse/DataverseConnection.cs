using Microsoft.Extensions.Options;
using Microsoft.PowerPlatform.Dataverse.Client;

namespace Waaree.Api.Dataverse;

// This class handles Dataverse connection/authentication.
// We are using Interactive Login, not ClientId/ClientSecret.
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

        return $"Dataverse Mode Enabled for {_dataverseSettings.EnvironmentUrl}";
    }

    // This creates Dataverse connection using interactive Microsoft login.
    public ServiceClient CreateClient()
    {
        var connectionString =
            $"AuthType=OAuth;" +
            $"Url={_dataverseSettings.EnvironmentUrl};" +
            $"ClientId=51f81489-12ee-4a9e-aaae-a2591f45987d;" +
            $"RedirectUri=http://localhost;" +
            $"LoginPrompt=Auto";

        return new ServiceClient(connectionString);
    }

    // This method checks whether ASP.NET can connect to Dataverse.
    public string TestConnection()
    {
        var client = CreateClient();

        if (client.IsReady)
        {
            return "Dataverse connection successful";
        }

        return $"Dataverse connection failed: {client.LastError}";
    }
}