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
        Task<User> Authenticate(string username, string password);
        Task<User> Register(string username, string password);

    }
    public class UserRepository : IUserRepository
    {
        private readonly FarmDbContext _context;

        public UserRepository(FarmDbContext context)
        {
            _context = context;
        }

        public async Task<User> Register(string username, string password)
        {
            // Verifica si el nombre de usuario ya está en uso
            if (await _context.User.AnyAsync(x => x.Usuario == username))
                return null;

            var user = new User
            {
                Usuario = username,
                Password = password
            };

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.Usuario == username);

            
            if (user == null || user.Password != password)
                return null;

            
            return user;
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
