using MediatR;

namespace ProjectManagementPlatform.Application.Commands
{
    public class CreateTaskCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
    }
}