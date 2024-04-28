using GameWeb.Context;
using GameWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Repositories
{
    public interface ITasksRepository
    {
        Task<List<Tasks>>GetTasks();
        Task<Tasks> GetTaskId(int id);
        Task<Tasks> AddTask(string Description, int Farmid);
        Task<Tasks> UpdateTask(Tasks task);
        Task<Tasks> DeleteTask(int id);
    }
    public class TasksRepository : ITasksRepository
    {
        private readonly FarmDbContext _context;

        public TasksRepository(FarmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tasks>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tasks> GetTaskId(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<Tasks> AddTask(string Description, int Farmid)
        {
            var task = new Tasks
            {
                Description = Description,
                FarmId = Farmid
            };

            await _context.Tasks.AddAsync(task);
            _context.SaveChanges();
            return task;
        }

        public async Task<Tasks> UpdateTask(Tasks task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Tasks> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return null;
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
