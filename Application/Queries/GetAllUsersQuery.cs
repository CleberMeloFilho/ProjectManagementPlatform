using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using System.Collections.Generic;

namespace ProjectManagementPlatform.Application.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}