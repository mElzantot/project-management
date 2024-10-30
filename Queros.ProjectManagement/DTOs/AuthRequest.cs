using System.ComponentModel.DataAnnotations;
using Queros.ProjectManagement.Data.Enums;

namespace Queros.ProjectManagement.DTOs;

public class AuthRequest
{
    [Required(AllowEmptyStrings = false)]
    public string UserName { get; set; }
    [Required(AllowEmptyStrings = false)]
    public string Password { get; set; }
    public UserRole Role { get; set; }
}