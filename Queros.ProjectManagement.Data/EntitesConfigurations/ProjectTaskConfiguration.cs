using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Queros.ProjectManagement.Data.Enums;
using Queros.ProjectManagement.Data.Models;

namespace Queros.ProjectManagement.Data.EntitiesConfigurations;

public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
{
    public void Configure(EntityTypeBuilder<ProjectTask> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status).HasConversion(new EnumToStringConverter<ProjectTaskStatus>());
        builder.Property(x => x.Priority).HasConversion(new EnumToStringConverter<TaskPriority>());
        
        builder.HasOne<Project>(x => x.Project)
            .WithMany(x => x.ProjectTasks)
            .HasForeignKey(x => x.ProjectId);
        
        builder.HasOne<User>(x => x.AssignedTo)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.AssigneeId);
    }
}