using GameWeb.Models;
using GameWeb.Repositories;

namespace GameWeb.Services
{
    public interface ITasksService
    {
        Task<List<Tasks>> GetTasks();
        Task<Tasks> GetTaskId(int id);
        Task<Tasks> AddTask(string Description, int FarmId);
        Task<Tasks> UpdateTask(int TaskId, string? Description = null, int? FarmId = null);
        Task<Tasks> DeleteTask(int id);
    }
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<List<Tasks>> GetTasks()
        {
            return await _tasksRepository.GetTasks();
        }

        public async Task<Tasks> GetTaskId(int id)
        {
            return await _tasksRepository.GetTaskId(id);
        }

        public async Task<Tasks> AddTask(string Description, int FarmId)
        {
            return await _tasksRepository.AddTask(Description, FarmId);
        }

        public async Task<Tasks> UpdateTask(int TaskId, string? Description = null, int? FarmId = null)
        {
            var task = await _tasksRepository.GetTaskId(TaskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            if (Description != null)
            {
                task.Description = Description;
            }

            if (FarmId != null)
            {
                task.FarmId = (int)FarmId;
            }

            return await _tasksRepository.UpdateTask(task);
        }
        public async Task<Tasks> DeleteTask(int id)
        {
            return await _tasksRepository.DeleteTask(id);
        }
    }
}
