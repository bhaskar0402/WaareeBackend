using Microsoft.AspNetCore.Mvc;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Messages;
using Waaree.Api.Dataverse;

namespace Waaree.Api.Controllers;

// TEMPORARY controller.
// Purpose: export Dataverse table/column metadata.
// Remove this before final production use.
[ApiController]
[Route("api/[controller]")]
public class DataverseMetadataController : ControllerBase
{
    private readonly DataverseConnection _dataverseConnection;

    public DataverseMetadataController(DataverseConnection dataverseConnection)
    {
        _dataverseConnection = dataverseConnection;
    }

    // GET: /api/dataversemetadata/table/cr034_task
    [HttpGet("table/{tableLogicalName}")]
    public IActionResult GetTableMetadata(string tableLogicalName)
    {
        var client = _dataverseConnection.CreateClient();

        if (!client.IsReady)
        {
            return BadRequest(new
            {
                success = false,
                message = client.LastError
            });
        }

        var request = new RetrieveEntityRequest
        {
            LogicalName = tableLogicalName,
            EntityFilters = EntityFilters.Attributes,
            RetrieveAsIfPublished = true
        };

        var response = (RetrieveEntityResponse)client.Execute(request);
        var table = response.EntityMetadata;

        var columns = table.Attributes.Select(a => new
        {
            displayName = a.DisplayName?.UserLocalizedLabel?.Label ?? "",
            logicalName = a.LogicalName,
            schemaName = a.SchemaName,
            type = a.AttributeType?.ToString(),
            requiredLevel = a.RequiredLevel?.Value.ToString()
        });

        return Ok(new
        {
            tableDisplayName = table.DisplayName?.UserLocalizedLabel?.Label ?? "",
            tableLogicalName = table.LogicalName,
            tableSchemaName = table.SchemaName,
            columns = columns
        });
    }
}