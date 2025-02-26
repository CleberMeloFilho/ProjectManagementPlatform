using ProjectManagementPlatform.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManagementPlatform.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace ProjectManagementPlatform.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetByIdAsync(int id);
        Task<IEnumerable<Role>> GetAllAsync();
        Task AddAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(int id);
    }
}