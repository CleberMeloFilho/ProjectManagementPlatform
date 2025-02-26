using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;

namespace ProjectManagementPlatform.Application.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description
            };

            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
}