using MediatR;

namespace ProjectManagementPlatform.Application.Commands
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}