using MediatR;
using ProjectManagementPlatform.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagementPlatform.Application.Commands
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            await _projectRepository.DeleteAsync(request.Id);
            await _projectRepository.SaveChangesAsync(cancellationToken);
        }
    }
}