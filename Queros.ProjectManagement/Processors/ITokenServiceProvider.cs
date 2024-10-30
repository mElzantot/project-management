using Queros.ProjectManagement.Data.Models;
using Queros.ProjectManagement.DTOs;

namespace Queros.ProjectManagement.Processors;

public interface ITokenServiceProvider
{
    AuthResponseDto GenerateAccessToken(User user);
}