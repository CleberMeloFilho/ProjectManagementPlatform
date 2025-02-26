using MediatR;

namespace ProjectManagementPlatform.Application.Commands
{
    public class UpdateTaskStatusCommand : IRequest
    {
        public int TaskId { get; set; }
        public TaskStatus Status { get; set; }
    }
}