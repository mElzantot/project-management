using Queros.ProjectManagement.Data.Enums;

namespace Queros.ProjectManagement.DTOs;

public class ProjectTaskDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProjectTaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }
    public Guid ProjectId { get; set; }
    public virtual ProjectDto? Project { get; set; }
    public Guid AssigneeId { get; set; }
    public UserDto Assignee { get; set; }
}