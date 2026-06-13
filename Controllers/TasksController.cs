using Microsoft.AspNetCore.Mvc;
using Waaree.Api.DTOs;
using Waaree.Api.Models;
using Waaree.Api.Services;

namespace Waaree.Api.Controllers;

// This class is an API Controller
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService;
    
    // Constructor
    // ASP.NET automatically gives TaskService here
    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }

    // GET /api/tasks
    // Return all tasks
    [HttpGet]
    public IActionResult GetAll()
    {
        // Call TaskService and return all tasks
        return Ok(_taskService.GetAll());
    }

    [HttpPost]
    public IActionResult Create(CreateTaskRequest request)
    {
        // Convert incoming request into TaskItem model
        var task = new TaskItem
        {
            TaskOwner = request.TaskOwner,
            Subject = request.Subject,
            DueDate = request.DueDate,
            Contact = request.Contact,
            Account = request.Account,
            Status = request.Status,
            Priority = request.Priority,
            ProductServices = request.ProductServices,
            PaymentTerms = request.PaymentTerms,
            Description = request.Description
        };

        // Send task to service layer
        _taskService.Add(task);

        return Ok(new
        {
            message = "Task created successfully",
            data = task
        });
    }
}