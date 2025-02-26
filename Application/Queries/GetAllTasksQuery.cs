using MediatR;
using ProjectManagementPlatform.Domain.Entities;
using System.Collections.Generic;
using Task = ProjectManagementPlatform.Domain.Entities.Task;

namespace ProjectManagementPlatform.Application.Queries
{
    public class GetAllTasksQuery : IRequest<IEnumerable<Task>>
    {
        public string StatusFilter { get; set; }
        public string SortBy { get; set; } // Ex: "Title", "Status", "DueDate"
        public bool SortAscending { get; set; } // true para ascendente, false para descendente
    }
}