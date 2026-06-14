using Microsoft.AspNetCore.Mvc;
using Waaree.Api.Dataverse;
using Waaree.Api.Models;

namespace Waaree.Api.Controllers;

// Temporary controller for testing real Dataverse CRUD.
// Later we can remove this after Task/Auth APIs are connected.
[ApiController]
[Route("api/[controller]")]
public class DataverseTestController : ControllerBase
{
    private readonly DataverseUserService _dataverseUserService;

    public DataverseTestController(DataverseUserService dataverseUserService)
    {
        _dataverseUserService = dataverseUserService;
    }

    // POST: /api/dataversetest/create-user
    // Creates one App User record in Dataverse.
    [HttpPost("create-user")]
    public IActionResult CreateUser()
    {
        var user = new AppUser
        {
            Name = "Mitesh Vaghela",
            Mobile = "9999999999",
            Email = "miteshvaghela@waaree.com",
            IsActive = true
        };

        var result = _dataverseUserService.CreateAppUser(user);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    // GET: /api/dataversetest/login/9999999999
    // Reads App User record from Dataverse by mobile number.
    [HttpGet("login/{mobile}")]
    public IActionResult LoginByMobile(string mobile)
    {
        var result = _dataverseUserService.LoginByMobile(mobile);

        if (!result.Success)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}