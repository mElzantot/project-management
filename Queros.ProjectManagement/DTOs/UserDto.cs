using Queros.ProjectManagement.Data.Enums;

namespace Queros.ProjectManagement.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}