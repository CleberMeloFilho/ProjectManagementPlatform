using MediatR;

namespace ProjectManagementPlatform.Application.Commands
{
    public class SendNotificationCommand : IRequest
    {
        public int UserId { get; set; }
        public string Message { get; set; }
    }
}