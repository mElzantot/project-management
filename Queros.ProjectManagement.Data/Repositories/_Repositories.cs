using Queros.ProjectManagement.Data.Models;

namespace Queros.ProjectManagement.Data.Repositories;

public class ProjectRepository : BaseRepository<ProjectManagementContext, Project, Guid>, IProjectRepository
{
    public ProjectRepository(ProjectManagementContext context) : base(context, (e, i) => e.Id = i)
    {
    }
}

public class ProjectTaskRepository(ProjectManagementContext context)
    : BaseRepository<ProjectManagementContext, ProjectTask, Guid>(context, (e, i) => e.Id = i), IProjectTaskRepository
{
}

public class UserRepository : BaseRepository<ProjectManagementContext, User, Guid>, IUserRepository
{
    public UserRepository(ProjectManagementContext context) : base(context, (e, i) => e.Id = i)
    {
    }
}
