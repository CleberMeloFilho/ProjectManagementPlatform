using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using System.Collections.Generic;

namespace ProjectManagementPlatform.Application.Queries
{
    public class GetProjectProgressQuery : IRequest<IEnumerable<ProjectProgressReport>>
    {
    }

    public class ProjectProgressReport
    {
        public string ProjectName { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public double ProgressPercentage => TotalTasks == 0 ? 0 : (CompletedTasks / (double)TotalTasks) * 100;
    }
}