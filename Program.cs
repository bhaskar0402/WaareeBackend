// Import Dataverse related classes
using Waaree.Api.Dataverse;

// Import Service classes
using Waaree.Api.Services;

// Create the ASP.NET application builder
var builder = WebApplication.CreateBuilder(args);

// Read AppSettings from appsettings.json
builder.Services.Configure<AppSettings>(builder.Configuration);

// Read Dataverse settings from appsettings.json
builder.Services.Configure<DataverseSettings>(
    builder.Configuration.GetSection("Dataverse"));

// Register Dataverse connection helper
builder.Services.AddSingleton<DataverseConnection>();

// Register DataverseService
// This service will communicate with Dataverse
builder.Services.AddSingleton<DataverseService>();

// Register Dataverse table-specific services
builder.Services.AddSingleton<DataverseUserService>();
builder.Services.AddSingleton<DataverseTaskService>();
builder.Services.AddSingleton<DataverseMeetingService>();

// Register AuthService
builder.Services.AddSingleton<AuthService>();
// Register DashboardService
builder.Services.AddSingleton<DashboardService>();
// Register MeetingService in Dependency Injection container
// Singleton = one object created and reused for entire application lifetime
builder.Services.AddSingleton<MeetingService>();
// Register TaskService
builder.Services.AddSingleton<TaskService>();

// Enable Controller support
// Without this, ASP.NET won't find your controllers
builder.Services.AddControllers();

// Enable API Explorer
// Used by Swagger to discover endpoints
builder.Services.AddEndpointsApiExplorer();

// Enable Swagger/OpenAPI generation
builder.Services.AddSwaggerGen();

// Build the application
var app = builder.Build();

// Run Swagger only in Development environment
if (app.Environment.IsDevelopment())
{
    // Generate OpenAPI document
    app.UseSwagger();

    // Show Swagger UI page
    app.UseSwaggerUI();
}

// Connect controller routes
// Example:
// /api/tasks
// /api/auth
// /api/dashboard
app.MapControllers();

// Start the web server
// Application now waits for incoming requests
app.Run();