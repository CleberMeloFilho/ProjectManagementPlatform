using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Task = ProjectManagementPlatform.Domain.Entities.Task;

namespace ProjectManagementPlatform.Application.Queries
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<Task>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllTasksQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async System.Threading.Tasks.Task<IEnumerable<Task>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllAsync();

            // Filtragem por status
            if (!string.IsNullOrEmpty(request.StatusFilter))
            {
                tasks = tasks.Where(t => t.Status.ToString() == request.StatusFilter);
            }

            // Ordenação
            if (!string.IsNullOrEmpty(request.SortBy))
            {
                switch (request.SortBy)
                {
                    case "Title":
                        tasks = request.SortAscending ? tasks.OrderBy(t => t.Title) : tasks.OrderByDescending(t => t.Title);
                        break;
                    case "Status":
                        tasks = request.SortAscending ? tasks.OrderBy(t => t.Status) : tasks.OrderByDescending(t => t.Status);
                        break;
                        // Adicione mais casos para outras propriedades, se necessário
                }
            }

            return tasks;
           
        }
    }
}