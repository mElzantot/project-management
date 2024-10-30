using Microsoft.AspNetCore.Mvc;
using Queros.ProjectManagement.DTOs;
using Queros.ProjectManagement.Services;

namespace Queros.ProjectManagement.Controller;

[Route("project-task")]
[ApiController]
public class ProjectTaskController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ILogger _logger;
    private readonly ProjectTaskService _projectTaskService;

    public ProjectTaskController(ILogger<ProjectTaskController> logger, ProjectTaskService projectTaskService)
    {
        _logger = logger;
        _projectTaskService = projectTaskService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTask(NewTaskRequest taskRequest)
    {
        try
        {
            var createTaskResult = await _projectTaskService.CreateNewTaskAsync(taskRequest);

            return createTaskResult.IsSuccess
                ? Ok(createTaskResult)
                : BadRequest(new { errors = createTaskResult.Errors.Select(x => x.Message).ToList()});
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectTask(Guid id)
    {
        try
        {
            var taskResult = await _projectTaskService.GetProjectTasksAsync(id);

            return taskResult.Count > 0
                ? Ok(taskResult)
                : NoContent();

        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpPut("{id}/assign-to/{assigneeId}")]
    public async Task<IActionResult> AssignProjectTask(Guid taskId, Guid assigneeId)
    {
        try
        {
            var assignmentResult = await _projectTaskService.AssignProjectTaskAsync(taskId, assigneeId);

            return assignmentResult.IsSuccess
                ? Accepted()
                : BadRequest(new { errors = assignmentResult.Errors.Select(x => x.Message).ToList() });

        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProjectTask(Guid id, NewTaskRequest taskRequest)
    {
        try
        {
            var updateResult = await _projectTaskService.UpdateProjectTaskAsync(id, taskRequest);

            return updateResult.IsSuccess
                ? Accepted()
                : BadRequest(new { errors = updateResult.Errors.Select(x => x.Message).ToList()});

        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    
}