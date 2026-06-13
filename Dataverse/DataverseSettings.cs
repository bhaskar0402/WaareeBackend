namespace Waaree.Api.Dataverse;

// This class stores Dataverse connection settings.
// Values will come from appsettings.json, not hardcoded inside service classes.
public class DataverseSettings
{
    public string EnvironmentUrl { get; set; } = "";
    public string WebApiUrl { get; set; } = "";
    public string TenantId { get; set; } = "";
    public string ClientId { get; set; } = "";
    public string ClientSecret { get; set; } = "";
}