using Queros.ProjectManagement.Data.Models;

namespace Queros.ProjectManagement.Data.Repositories;


public interface IProjectRepository : IBaseRepository<Project, Guid>
{
}

public interface IProjectTaskRepository : IBaseRepository<ProjectTask, Guid>
{
}

public interface IUserRepository : IBaseRepository<User, Guid>
{
}

