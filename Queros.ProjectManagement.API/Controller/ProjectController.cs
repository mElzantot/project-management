using Microsoft.AspNetCore.Mvc;
using Queros.ProjectManagement.DTOs;
using Queros.ProjectManagement.Services;
using Subsbase.Balance.Inputs;

namespace Queros.ProjectManagement.Controller;

[Route("project")]
[ApiController]
public class ProjectController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ILogger _logger;
    private readonly ProjectService _projectService;

    public ProjectController(ILogger<ProjectController> logger, ProjectService projectService)
    {
        _logger = logger;
        _projectService = projectService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProject(NewProjectRequest projectRequest)
    {
        try
        {
            var createProjectResult = await _projectService.CreateNewProject(projectRequest);

            return createProjectResult.IsSuccess
                ? Ok(createProjectResult.Value)
                : BadRequest(new { errors = createProjectResult.Errors.Select(x => x.Message).ToList()});
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProject(Guid id)
    {
        try
        {
            var projectsResult = await _projectService.GetProjectAsync(id);

            return projectsResult != null
                ? Ok(projectsResult)
                : BadRequest(new { errors = $"Project with Id: {id} doesn't exist"});

        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProjects([FromQuery] PaginationInput pagination)
    {
        try
        {
            var projectsResult = await _projectService.GetProjectsAsync(pagination);

            return projectsResult.Count > 0
                ? Ok(new {data = projectsResult})
                : NoContent();

        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProject(Guid id, NewProjectRequest projectRequest)
    {
        try
        {
            var updateResult = await _projectService.UpdateProjectAsync(id, projectRequest);

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