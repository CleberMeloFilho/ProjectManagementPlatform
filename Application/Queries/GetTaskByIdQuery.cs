using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using Task = ProjectManagementPlatform.Domain.Entities.Task;

namespace ProjectManagementPlatform.Application.Queries
{
    public class GetTaskByIdQuery : IRequest<Task>
    {
        public int Id { get; set; }
    }
}