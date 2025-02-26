using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;

namespace ProjectManagementPlatform.Application.Queries
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetByIdAsync(request.Id);
        }
    }
}