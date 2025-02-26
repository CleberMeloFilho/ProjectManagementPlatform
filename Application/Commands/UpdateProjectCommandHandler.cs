using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagementPlatform.Application.Commands
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project != null)
            {
                project.Name = request.Name;
                project.Description = request.Description;

                _projectRepository.UpdateAsync(project);
                await _projectRepository.SaveChangesAsync(cancellationToken);
            }
        }
    }
}