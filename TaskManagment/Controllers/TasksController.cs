using Microsoft.AspNetCore.Mvc;
using TaskManagement.Models;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    /// <summary>
    /// API controller for managing tasks.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _taskService.GetAllTasksAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            var created = await _taskService.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskItem task)
        {
            var success = await _taskService.UpdateTaskAsync(id, task);
            return success ? NoContent() : NotFound();
        }
        // IMPORTANT:
        // Here currently hard delete is performed.
        // This is not preferred for live/production projects.
        // Always use soft delete instead by adding an `IsDeleted` column in the entity
        // and filtering out logically deleted records from queries.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _taskService.DeleteTaskAsync(id);
            return success ? NoContent() : NotFound();
        }
    }

}
