using MediatR;
using ProjectManagementPlatform.Domain.Entities;

namespace ProjectManagementPlatform.Application.Queries
{
    public class GetProjectByIdQuery : IRequest<Project>
    {
        public int Id { get; set; }
    }
}