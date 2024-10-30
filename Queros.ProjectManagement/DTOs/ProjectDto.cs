using Queros.ProjectManagement.Data.Enums;

namespace Queros.ProjectManagement.DTOs;

public class ProjectDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Budget { get; set; }
    public string Owner { get; set; } = string.Empty;
    public ProjectStatus Status { get; set; }
    public virtual List<ProjectTaskDto>? ProjectTasks { get; set; }
}