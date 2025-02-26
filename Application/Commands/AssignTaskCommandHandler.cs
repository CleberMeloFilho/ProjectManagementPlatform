using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using TaskStatus = ProjectManagementPlatform.Domain.Entities.TaskStatus;

namespace ProjectManagementPlatform.Application.Commands
{
    public class AssignTaskCommandHandler : IRequestHandler<AssignTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public AssignTaskCommandHandler(ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public async System.Threading.Tasks.Task Handle(AssignTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.TaskId);
            var user = await _userRepository.GetByIdAsync(request.AssignedToUserId);

            if (task == null || user == null)
            {
                throw new System.Exception("Task or User not found.");
            }

            // Verificar se o usuário que está atribuindo a tarefa é um gerente
            // (Implementar lógica de autorização aqui)

            task.AssignedToUserId = request.AssignedToUserId;
            task.Status = TaskStatus.InProgress; // Atualizar o status da tarefa

            _taskRepository.UpdateAsync(task);
            await _taskRepository.SaveChangesAsync(cancellationToken);

            // Enviar notificação ao usuário
            var notificationCommand = new SendNotificationCommand
            {
                UserId = request.AssignedToUserId,
                Message = $"You have been assigned to the task: {task.Title}"
            };
            await _mediator.Send(notificationCommand);
        }
       
    }
}