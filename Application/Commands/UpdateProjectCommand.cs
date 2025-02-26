using MediatR;

namespace ProjectManagementPlatform.Application.Commands
{
    public class UpdateProjectCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}