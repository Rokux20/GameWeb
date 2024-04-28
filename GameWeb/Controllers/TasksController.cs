using GameWeb.Context;
using GameWeb.Models;
using GameWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;
        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Tasks>>> GetTasks()
        {
            return Ok(await _tasksService.GetTasks());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTaskId(int id)
        {
            var task = await _tasksService.GetTaskId(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Tasks>> AddTask([FromBody] Tasks task)
        {
            return Ok(await _tasksService.AddTask(task.Description, task.FarmId));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tasks>> UpdateTask(int id, [FromBody] Tasks task)
        {
            try
            {
                return Ok(await _tasksService.UpdateTask(id, task.Description, task.FarmId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Tasks>> DeleteTask(int id)
        {
            var task = await _tasksService.DeleteTask(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
    }
}
