using Microsoft.EntityFrameworkCore;
using Queros.ProjectManagement.Data.EntitiesConfigurations;
using Queros.ProjectManagement.Data.Enums;

namespace Queros.ProjectManagement.Data.Models;

[EntityTypeConfiguration(typeof(UserConfiguration))]
public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public string? PasswordHash { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpirationDate { get; set; }
    public DateTime CreationDate { get; set; }
    public virtual List<ProjectTask>? Tasks { get; set; }
}
