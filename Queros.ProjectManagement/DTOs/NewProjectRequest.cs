using System.ComponentModel.DataAnnotations;

namespace Queros.ProjectManagement.DTOs;

public class NewProjectRequest
{
    [Required(AllowEmptyStrings = false)] public string Name { get; set; }
    [Required(AllowEmptyStrings = false)] public string Description { get; set; }
    [Required(AllowEmptyStrings = false)] public string Owner { get; set; }
    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime EndDate { get; set; }
    [Required] public decimal Budget { get; set; }
}