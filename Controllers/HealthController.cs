using Microsoft.AspNetCore.Mvc;
using Waaree.Api.Dataverse;

namespace Waaree.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    private readonly DataverseService _dataverseService;

    public HealthController(DataverseService dataverseService)
    {
        _dataverseService = dataverseService;
    }

    // GET: /api/health
    // This checks whether the ASP.NET API is running
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "Waaree Backend API is running",
            time = DateTime.Now
        });
    }


    // GET: /api/health/dataverse-test
// This checks real Dataverse connection using Interactive Login
    // GET: /api/health/dataverse-test
// This checks real Dataverse connection using Interactive Login
    [HttpGet("dataverse-test")]
    public IActionResult TestDataverseConnection()
    {
        return Ok(new
        {
            status = _dataverseService.GetStatus(),
            connectionTest = _dataverseService.TestConnection()
        });
    }
    // GET: /api/health/dataverse
    // This checks whether DataverseService is registered correctly
    [HttpGet("dataverse")]
    public IActionResult CheckDataverseService()
    {
        return Ok(new
        {
            status = _dataverseService.GetStatus()
        });
    }
}