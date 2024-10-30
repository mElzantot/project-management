using System.ComponentModel.DataAnnotations;
using Queros.ProjectManagement.Data.Enums;

namespace Queros.ProjectManagement.DTOs;

public class NewTaskRequest
{
    [Required] public Guid Id { get; set; }
    [Required(AllowEmptyStrings = false)] public string Name { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)] public string Description { get; set; } = string.Empty;
    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime EndDate { get; set; }
    [Required] public TaskPriority Priority { get; set; }
    [Required] public Guid ProjectId { get; set; }
    [Required] public Guid AssigneeId { get; set; }
}