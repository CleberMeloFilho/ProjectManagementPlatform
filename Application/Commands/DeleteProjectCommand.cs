using MediatR;

namespace ProjectManagementPlatform.Application.Commands
{
    public class DeleteProjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}