using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManagementPlatform.Domain.Entities;
using Task = ProjectManagementPlatform.Domain.Entities.Task;

namespace ProjectManagementPlatform.Domain.Repositories
{
    public interface IUserRepository
    {
        System.Threading.Tasks.Task<User> GetByIdAsync(int id);
        System.Threading.Tasks.Task<User> GetByUsernameAsync(string username);
        System.Threading.Tasks.Task<IEnumerable<User>> GetAllAsync(); // Método que precisa ser implementado
        System.Threading.Tasks.Task AddAsync(User user);
        System.Threading.Tasks.Task UpdateAsync(User user);
        System.Threading.Tasks.Task DeleteAsync(int id);
        System.Threading.Tasks.Task SaveChangesAsync(CancellationToken cancellationToken = default); // Adicionado
        
    }
}