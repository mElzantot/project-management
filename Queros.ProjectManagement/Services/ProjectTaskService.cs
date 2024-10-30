using FluentResults;
using Queros.ProjectManagement.Data.Enums;
using Queros.ProjectManagement.Data.Models;
using Queros.ProjectManagement.Data.Repositories;
using Queros.ProjectManagement.DTOs;

namespace Queros.ProjectManagement.Services;

public class ProjectTaskService(IProjectTaskRepository projectTaskRepository)
{
    public async Task<Result> CreateNewTaskAsync(NewTaskRequest taskRequest)
    {
       var result =  await projectTaskRepository.AddAsync(new ProjectTask()
        {
            ProjectId = taskRequest.ProjectId,
            Name = taskRequest.Name,
            Description = taskRequest.Description,
            Status = ProjectTaskStatus.NotStarted,
            Priority = taskRequest.Priority,
            StartDate = taskRequest.StartDate,
            EndDate = taskRequest.EndDate,
            AssigneeId = taskRequest.AssigneeId
        });

        return Result.Ok();
    }

    public async Task<List<ProjectTaskDto>> GetProjectTasksAsync(Guid projectId)
    {
        return await projectTaskRepository.GetAllAsync(x => new ProjectTaskDto()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Status = x.Status,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            Assignee = new UserDto()
            {
                Name = x.Name,
                Id = x.AssignedTo.Id,
            }
        },
            predicate: x => x.ProjectId == projectId);
    }

    public async Task<Result> UpdateProjectTaskAsync(Guid id, NewTaskRequest taskRequest)
    {
        var result = await projectTaskRepository.UpdateAsync(id, x =>
        {
            x.Name = taskRequest.Name;
            x.Description = taskRequest.Description;
            x.StartDate = taskRequest.StartDate;
            x.EndDate = taskRequest.EndDate;
            x.AssigneeId = taskRequest.AssigneeId;
        });

        return Result.Ok();
    }

    public async Task<Result> AssignProjectTaskAsync(Guid taskId, Guid assigneeId)
    {
        var result = await projectTaskRepository.UpdateAsync(taskId, x => x.AssigneeId = assigneeId);
        return Result.Ok();
    }
}