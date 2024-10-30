using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Queros.ProjectManagement.Data.EntitiesConfigurations;
using Queros.ProjectManagement.Data.Enums;

namespace Queros.ProjectManagement.Data.Models;

[EntityTypeConfiguration(typeof(ProjectTaskConfiguration))]
public class ProjectTask
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ProjectTaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }

    public Guid ProjectId { get; set; }
    public virtual Project? Project { get; set; }
    
    public Guid AssigneeId { get; set; }
    public virtual User? AssignedTo { get; set; }
}