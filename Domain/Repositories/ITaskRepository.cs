using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManagementPlatform.Domain.Entities;
using Task = ProjectManagementPlatform.Domain.Entities.Task;

namespace ProjectManagementPlatform.Domain.Repositories
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task<Task> GetByIdAsync(int id); // Usando Task<T> do System.Threading.Tasks
        System.Threading.Tasks.Task<IEnumerable<Task>> GetAllAsync(); // Usando Task<T> do System.Threading.Tasks
        System.Threading.Tasks.Task AddAsync(Task task); // Usando Task do System.Threading.Tasks
        System.Threading.Tasks.Task UpdateAsync(Task task); // Usando Task do System.Threading.Tasks
        System.Threading.Tasks.Task DeleteAsync(int id); // Usando Task do System.Threading.Tasks

        System.Threading.Tasks.Task SaveChangesAsync(CancellationToken cancellationToken = default); // Adicionado
    }
}