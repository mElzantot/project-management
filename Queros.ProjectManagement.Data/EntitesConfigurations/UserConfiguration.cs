using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Queros.ProjectManagement.Data.Enums;
using Queros.ProjectManagement.Data.Models;

namespace Queros.ProjectManagement.Data.EntitiesConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Role).HasConversion(new EnumToStringConverter<UserRole>());

    }
}