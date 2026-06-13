using Microsoft.AspNetCore.Mvc;
using Waaree.Api.Services;

namespace Waaree.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly DashboardService _dashboardService;

    // DashboardService is injected here using Dependency Injection
    public DashboardController(DashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    // GET: /api/dashboard
    // This API returns dashboard summary data
    [HttpGet]
    public IActionResult GetDashboard()
    {
        var dashboardData = _dashboardService.GetDashboardData();

        return Ok(dashboardData);
    }
}