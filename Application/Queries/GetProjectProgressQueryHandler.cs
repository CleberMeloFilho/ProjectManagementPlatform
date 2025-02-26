using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskStatus = ProjectManagementPlatform.Domain.Entities.TaskStatus;

namespace ProjectManagementPlatform.Application.Queries
{
    public class GetProjectProgressQueryHandler : IRequestHandler<GetProjectProgressQuery, IEnumerable<ProjectProgressReport>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectProgressQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async System.Threading.Tasks.Task<IEnumerable<ProjectProgressReport>> Handle(GetProjectProgressQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllAsync();
            var reports = new List<ProjectProgressReport>();

            foreach (var project in projects)
            {
                var totalTasks = project.Tasks.Count;
                var completedTasks = project.Tasks.Count(t => t.Status == TaskStatus.Completed);

                reports.Add(new ProjectProgressReport
                {
                    ProjectName = project.Name,
                    TotalTasks = totalTasks,
                    CompletedTasks = completedTasks
                });
            }

            return reports;
        }
    }
}