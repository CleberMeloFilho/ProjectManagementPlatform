using MediatR;

namespace ProjectManagementPlatform.Application.Commands
{
    public class AssignTaskCommand : IRequest
    {
        public int TaskId { get; set; }
        public int AssignedToUserId { get; set; }
    }
}