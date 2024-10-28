using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Queros.ProjectManagement.Data.Enums;
using Queros.ProjectManagement.Data.Models;

namespace Queros.ProjectManagement.Data.EntitiesConfigurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status).HasConversion(new EnumToStringConverter<ProjectStatus>());
    }
}