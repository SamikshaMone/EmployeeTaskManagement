using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using EmployeeTaskManagementSystem.Models;
using EmployeeTaskManagementSystem.Services;
using EmployeeTaskManagementSystem.Hubs;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly IHubContext<NotificationHub> _hubContext;

    public TaskController(ITaskService taskService, IHubContext<NotificationHub> hubContext)
    {
        _taskService = taskService;
        _hubContext = hubContext;
    }

    [HttpPost("assign")]
    public async Task<IActionResult> AssignTask([FromBody] TaskModel task)
    {
        await _taskService.AssignTaskAsync(task);
        await _hubContext.Clients.All.SendAsync("TaskUpdated", task);
        return Ok("Task Assigned");
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskModel updatedTask)
    {
        var result = await _taskService.UpdateTaskAsync(id, updatedTask);
        if (!result)
            return NotFound("Task not found");
        await _hubContext.Clients.All.SendAsync("TaskUpdated", updatedTask);
        return Ok("Task updated");
    }
}

