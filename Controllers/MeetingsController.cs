using Microsoft.AspNetCore.Mvc;
using Waaree.Api.DTOs;
using Waaree.Api.Models;
using Waaree.Api.Services;

namespace Waaree.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetingsController : ControllerBase
{
    private readonly MeetingService _meetingService;

    public MeetingsController(MeetingService meetingService)
    {
        _meetingService = meetingService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_meetingService.GetAll());
    }

    [HttpPost]
    public IActionResult Create(CreateMeetingRequest request)
    {
        var meeting = new Meeting
        {
            Title = request.Title,
            MeetingVenue = request.MeetingVenue,
            Location = request.Location,
            FromDateTime = request.FromDateTime,
            ToDateTime = request.ToDateTime,
            Host = request.Host,
            Account = request.Account,
            Contact = request.Contact,
            EventStatus = request.EventStatus,
            ProductServices = request.ProductServices,
            Description = request.Description
        };

        _meetingService.Add(meeting);

        return Ok(new
        {
            message = "Meeting created successfully",
            data = meeting
        });
    }
}