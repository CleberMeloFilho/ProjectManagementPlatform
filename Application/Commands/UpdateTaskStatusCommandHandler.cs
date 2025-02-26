using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagementPlatform.Application.Commands
{
    public class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public UpdateTaskStatusCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.TaskId);

            if (task == null)
            {
                throw new System.Exception("Task not found.");
            }

            task.Status = (Domain.Entities.TaskStatus)request.Status;

            _taskRepository.UpdateAsync(task);
            await _taskRepository.SaveChangesAsync(cancellationToken);
        }



    }
}