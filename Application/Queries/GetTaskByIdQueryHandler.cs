using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Task = ProjectManagementPlatform.Domain.Entities.Task;

namespace ProjectManagementPlatform.Application.Queries
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Task>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskByIdQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async System.Threading.Tasks.Task<Task> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _taskRepository.GetByIdAsync(request.Id);
        }
    }
}