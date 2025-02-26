using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagementPlatform.Application.Commands
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new ProjectManagementPlatform.Domain.Entities.Task
            {
                Title = request.Title,
                Description = request.Description,
                ProjectId = request.ProjectId,
                Status = ProjectManagementPlatform.Domain.Entities.TaskStatus.Pending // Status inicial
            };

            await _taskRepository.AddAsync(task);
            await _taskRepository.SaveChangesAsync(cancellationToken);

            return task.Id;
        }
    }
}