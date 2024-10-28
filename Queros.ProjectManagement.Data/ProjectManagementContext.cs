﻿using Microsoft.EntityFrameworkCore;
using Queros.ProjectManagement.Data.Models;

namespace Queros.ProjectManagement.Data;

public class ProjectManagementContext : DbContext
{
    public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
}