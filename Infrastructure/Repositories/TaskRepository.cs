using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;
using ProjectManagementPlatform.Infrastructure.Data;
using Task = ProjectManagementPlatform.Domain.Entities.Task;


namespace ProjectManagementPlatform.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<Task> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async System.Threading.Tasks.Task<IEnumerable<Task>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async System.Threading.Tasks.Task AddAsync(Task task)
        {
            await _context.Tasks.AddAsync(task);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Task task)
        {
            _context.Tasks.Update(task);
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
            }
        }

        public async System.Threading.Tasks.Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}