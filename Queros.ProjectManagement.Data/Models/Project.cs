using Microsoft.EntityFrameworkCore;
using Queros.ProjectManagement.Data.EntitiesConfigurations;
using Queros.ProjectManagement.Data.Enums;

namespace Queros.ProjectManagement.Data.Models;

[EntityTypeConfiguration(typeof(ProjectConfiguration))]
public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Budget { get; set; }
    public string Owner { get; set; } = string.Empty;
    public ProjectStatus Status { get; set; }

    public virtual List<ProjectTask>? ProjectTasks { get; set; }
}