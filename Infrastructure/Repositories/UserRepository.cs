using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagementPlatform.Domain.Entities;
using ProjectManagementPlatform.Domain.Repositories;
using ProjectManagementPlatform.Infrastructure.Data;

namespace ProjectManagementPlatform.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async System.Threading.Tasks.Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async System.Threading.Tasks.Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async System.Threading.Tasks.Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public async System.Threading.Tasks.Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync(); // Implementação do método
        }
    }
}