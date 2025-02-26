using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManagementPlatform.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace ProjectManagementPlatform.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetByIdAsync(int id);
        Task<IEnumerable<Project>> GetAllAsync();
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(int id);
        Task SaveChangesAsync(CancellationToken cancellationToken = default); // Adicionado

       
    }
}