using MediatR;
using ProjectManagementPlatform.Domain.Entities;

namespace ProjectManagementPlatform.Application.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}