using FluentResults;
using Queros.ProjectManagement.Data.Enums;
using Queros.ProjectManagement.Data.Models;
using Queros.ProjectManagement.Data.Repositories;
using Queros.ProjectManagement.DTOs;
using Subsbase.Balance.Inputs;

namespace Queros.ProjectManagement.Services;

public class ProjectService(IProjectRepository projectRepository)
{
    public async Task<Result<Guid>> CreateNewProject(NewProjectRequest projectRequest)
    {
       var result =  await projectRepository.AddAsync(new Project
        {
            Name = projectRequest.Name,
            Description = projectRequest.Description,
            Budget = projectRequest.Budget,
            Status = ProjectStatus.NotStarted,
            StartDate = projectRequest.StartDate,
            EndDate = projectRequest.EndDate
        });

        return Result.Ok();
    }

    public async Task<List<ProjectDto>> GetProjectsAsync(PaginationInput pagination)
    {
        return await projectRepository.GetAllAsync(x => new ProjectDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Budget = x.Budget,
                Status = x.Status,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Owner = x.Owner
            },
            skip: (pagination.PageNumber - 1) * pagination.PageSize,
            limit: pagination.PageSize);
    }

    public async Task<ProjectDto?> GetProjectAsync(Guid id)
    {
        return await projectRepository.GetFirstAsync(x => new ProjectDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Budget = x.Budget,
                Status = x.Status,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            },
            x => x.Id == id);
    }

    public async Task<Result> UpdateProjectAsync(Guid id, NewProjectRequest projectRequest)
    {
        var result = await projectRepository.UpdateAsync(id, x =>
        {
            x.Name = projectRequest.Name;
            x.Description = projectRequest.Description;
            x.Budget = projectRequest.Budget;
            x.StartDate = projectRequest.StartDate;
            x.EndDate = projectRequest.EndDate;
        });

        return Result.Ok();
    }
}