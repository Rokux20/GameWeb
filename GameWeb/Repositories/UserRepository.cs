using GameWeb.Context;
using GameWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserId(int id);
        Task<User> AddUser(string Usuario, string Password);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);

    }
    public class UserRepository : IUserRepository
    {
        private readonly FarmDbContext _context;

        public UserRepository(FarmDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserId(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<User> AddUser(string Usuario, string Password)
        {
            var user = new User
            {
                Usuario = Usuario,
                Password = Password
            };

            await _context.User.AddAsync(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }  
}
