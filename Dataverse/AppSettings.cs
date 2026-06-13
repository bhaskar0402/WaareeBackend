namespace Waaree.Api.Dataverse;

// This class stores general app settings from appsettings.json.
public class AppSettings
{
    // If false, app uses temporary memory data.
    // If true, app will use Dataverse.
    public bool UseDataverse { get; set; }
}