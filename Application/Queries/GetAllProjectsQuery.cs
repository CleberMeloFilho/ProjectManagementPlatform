using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using System.Collections.Generic;

namespace ProjectManagementPlatform.Application.Queries
{
    public class GetAllProjectsQuery : IRequest<IEnumerable<Project>>
    {
        // Esta query não precisa de propriedades adicionais
    }
}